using infusync.DataTier.Repository;
using IdentityModel;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using OENT.Entities;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApplicationHost
{
    public class ProfileService : IProfileService
    {
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _claimsFactory;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IApplicationUserDbContext _userRepository;

        public ProfileService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, IApplicationUserDbContext userRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _claimsFactory = claimsFactory;
            _userRepository = userRepository;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            //var sub = context.Subject.GetSubjectId();
            //var user = await _userManager.FindByIdAsync(sub);
            //var principal = await _claimsFactory.CreateAsync(user);

            //var claims = principal.Claims.ToList();
            //claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();
            //claims.Add(new Claim(JwtClaimTypes.GivenName, user.FirstName));
            //claims.Add(new Claim(JwtClaimTypes.FamilyName, user.LastName));
            //claims.Add(new Claim(JwtClaimTypes.Email, user.Email));
            //claims.Add(new Claim(JwtClaimTypes.Name, user.LastName + ", " + user.FirstName));
            //claims.Add(new Claim(JwtClaimTypes.Role, user.Role));

            //claims.Add(new Claim("admin", user.Admin.ToString()));
            //claims.Add(new Claim(JwtClaimTypes.Id, user.Id.ToString()));
            //context.IssuedClaims = claims;

            var sub = context.Subject.GetSubjectId();
            var user = await _userManager.FindByIdAsync(sub);

            var principal = await _claimsFactory.CreateAsync(user);

            var claims = principal.Claims.ToList();
            claims = claims.Where(claim => context.RequestedClaimTypes.Contains(claim.Type)).ToList();

            var userClaims = await _userManager.GetClaimsAsync(user);

            foreach (var claim in userClaims)
            {
                claims.Add(new Claim(claim.Type, claim.Value));
            }

            var userRoleClaim = userClaims.FirstOrDefault(s => s.Type == JwtClaimTypes.Role);
            if (userRoleClaim != null)
            {
                var userRole = await _roleManager.FindByNameAsync(userRoleClaim.Value);
                claims.Add(new Claim("role_sub", userRole.Id.ToString()));
            }

            if (!string.IsNullOrEmpty(user.TenantId))
                claims.Add(new Claim("company_id", user.TenantId));

            context.IssuedClaims = claims;
        }


        public async Task IsActiveAsync(IsActiveContext context)
        {
            //ApplicationUser user = null;
            //var obj = context.Subject.GetSubjectId();
            //if (!ObjectId.TryParse(obj, out ObjectId id))
            //{
            //    user = _userManager.Users.Where(x => x.Email == obj).FirstOrDefault();
            //}
            //else
            //{
            //    user = _userManager.Users.Where(x => x.Id == ObjectId.Parse(obj)).FirstOrDefault();
            //}
            var sub = context.Subject.Identity.GetSubjectId();
            var user = await _userRepository.GetUserById(sub);
            context.IsActive = user.IsActive;
        }
    }
}