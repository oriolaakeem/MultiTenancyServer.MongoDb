using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApplicationHost.Extensions;
using ApplicationHost.Services;
using IdentityModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OENT.Entities;

namespace ApplicationHost.Quickstart.Account
{
    [Produces("application/json")]
    [Route("api/AccountAPI")]
    public class AccountAPIController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ILogger _logger;
        private readonly IEmailSender _emailSender;

        public AccountAPIController(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager,
            ILoggerFactory loggerFactory, IConfiguration configuration, IHostingEnvironment environment,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _emailSender = emailSender;
            _roleManager = roleManager;
            Configuration = configuration;
            Environment = environment;
            _logger = loggerFactory.CreateLogger<AccountAPIController>();
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        [HttpGet]
        public JsonResult Get()
        {
            var ret = _userManager.Users;
            return Json(ret);
        }

        [HttpGet("{id}")]
        public async Task<JsonResult> Get(string id)
        {
            var dbUser = await _userManager.FindByIdAsync(id);
            return Json(dbUser);
        }

        [HttpGet("GetRoleById/{id}")]
        public async Task<JsonResult> GetRoleById(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
                return Json(role);

            return null;
        }

        [HttpGet, Route("BanUser/{id}")]
        public async Task<JsonResult> BanUser(string id)
        {
            var dbUser = await _userManager.FindByIdAsync(id);
            if (dbUser != null)
            {
                dbUser.IsBanned = true;
                var res = await _userManager.UpdateAsync(dbUser);
                if (res.Succeeded)
                {
                    _logger.LogInformation($"User '{dbUser.UserName}' has been banned from the breeze platform");
                    return Json("Success");
                }

                _logger.LogError($"Error banning user '{dbUser.UserName}'.", res.Errors.First().Description);
            }

            return Json("Error banning user");
        }

        [HttpGet, Route("ReinstateUser/{id}")]
        public async Task<JsonResult> ReinstateUser(string id)
        {
            var dbUser = await _userManager.FindByIdAsync(id);
            if (dbUser != null)
            {
                dbUser.IsBanned = false;
                var res = await _userManager.UpdateAsync(dbUser);
                if (res.Succeeded)
                {
                    _logger.LogInformation($"User '{dbUser.UserName}' has been reinstated on the breeze platform");
                    return Json("Success");
                }

                _logger.LogError($"Error reinstating user '{dbUser.UserName}'.", res.Errors.First().Description);
            }
            return Json("Error reinstating user");
        }

        [HttpGet, Route("TerminateUser/{id}")]
        public async Task<JsonResult> TerminateUser(string id)
        {
            var dbUser = await _userManager.FindByIdAsync(id);
            if (dbUser != null)
            {
                dbUser.TenantId = string.Empty;
                var res = await _userManager.UpdateAsync(dbUser);
                if (res.Succeeded)
                {
                    _logger.LogInformation($"User '{dbUser.UserName}' has been terminated by a company on the breeze platform");
                    return Json("Success");
                }

                _logger.LogError($"Error terminating user '{dbUser.UserName}'.", res.Errors.First().Description);
            }
            return Json("Error terminating user");
        }

        [HttpPost]
        public async Task<JsonResult> Post([FromBody] UserInputModel userModel)
        {

            if (ModelState.IsValid)
            {
                IdentityResult result = null;
                var user = new ApplicationUser() { UserName = userModel.Email, Email = userModel.Email, PhoneNumber = userModel.Phone, TenantId = userModel.TenantId };
                var password = GeneratePassword(12);
                if (userModel.Role.Equals("Administrators"))
                    result = await _userManager.CreateAsync(user, password);
                else
                    result = await _userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    var link = string.Empty;
                    if (Environment.IsDevelopment())
                        link = Configuration["HostSettings:FrontEndUrl"];
                    else
                        link = Configuration["HostSettings:RemoteFrontEndUrl"];
                    _logger.LogInformation("User Account created with password.");

                    if (userModel.Role.Equals("Staff"))
                    {
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                        await _emailSender.SendEmailConfirmationAsync(userModel, callbackUrl);
                    }
                    else
                    {
                        await _emailSender.SendPasswordAsync(userModel, password, link);
                    }

                    //Add this user to a role

                    result = await _userManager.AddToRoleAsync(user, userModel.Role);
                    if (!result.Succeeded)
                    {
                        _logger.LogError($"Error adding user '{userModel.Email}' to a role", result.Errors);
                        Json($"Error adding user '{userModel.Email}' to a role");
                    }


                    var userRoles = await _userManager.GetRolesAsync(user);
                    string fullname = string.IsNullOrEmpty(userModel.MiddleName) ? userModel.LastName + " " + userModel.FirstName : userModel.LastName + ", " + userModel.FirstName + " " + userModel.MiddleName;
                    result = await _userManager.AddClaimsAsync(user, new Claim[]
                    {
                        new Claim(JwtClaimTypes.Name, fullname),
                        new Claim(JwtClaimTypes.GivenName, userModel.FirstName),
                        new Claim(JwtClaimTypes.FamilyName, userModel.LastName),
                        new Claim(JwtClaimTypes.Role, string.Join(',', userRoles)),
                        new Claim(JwtClaimTypes.Email, userModel.Email)
                    });

                    if (!result.Succeeded)
                    {
                        _logger.LogError(result.Errors.First().Description);
                        return Json("Error adding claims");

                    }
                    await _userManager.UpdateAsync(user);
                    var res = await _userManager.FindByEmailAsync(userModel.Email);

                    return Json(res);
                }
                else
                    return Json("Error Creating User!");
            }

            return Json("Error Creating User!");
        }

        #region Helpers

        private static string GeneratePassword(int maxSize)
        {
            char[] chars = new char[62];
            chars =
            @"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890()`~!@#$%^&*-+=|\{}[]:;'<>,?/".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        #endregion
    }
}