using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using infusync.DataTier.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using OryxDomainServices;
using OENT.Entities;

namespace infusync.DataTier.DbContexts
{
    public class ApplicationUserDbContext : IApplicationUserDbContext
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private IRepository<ApplicationUser> _repository;

        public IEnumerable<ApplicationUser> Users
        {
            get { return _repository.GetAll(); }
        }

        public bool SupportsUserRole { get; set; }

        public ApplicationUserDbContext(IRepository<ApplicationUser> repository, UserManager<ApplicationUser> userManager, IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _passwordHasher = passwordHasher;
            _repository = repository;
            _userManager = userManager;
        }

        public ApplicationUser AutoProvisionUser(string provider, string providerUserId, List<Claim> list)
        {
            throw new NotImplementedException();
        }

        public ApplicationUser FindByExternalProvider(string provider, string providerUserId)
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> GetUserById(string id)
        {
            var obj = id;
            if (!ObjectId.TryParse(obj, out ObjectId ido))
            {
                return GetUserByUsername(obj);
            }
            else
            {
                return _repository.GetAll().AsQueryable().ToAsyncEnumerable().Where(u => u.Id == ido).FirstOrDefault();
            }
        }

        public Task<ApplicationUser> GetUserByUsername(string username)
        {
            return _repository.GetAll().AsQueryable().ToAsyncEnumerable().Where(u => u.UserName == username).FirstOrDefault();
        }

        public bool ValidatePassword(string username, string plainTextPassword)
        {
            var user = GetUserByUsername(username).Result;
            if (user == null)
            {
                return false;
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, plainTextPassword);
            switch (result)
            {
                case PasswordVerificationResult.Success:
                    return true;
                case PasswordVerificationResult.Failed:
                    return false;
                case PasswordVerificationResult.SuccessRehashNeeded:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();
            }
        }

        public void AddApplicationUser(ApplicationUser entity)
        {
            _repository.Add(entity);
        }

        public async Task<IList<string>> GetRoles(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user);
        }

        public void Dispose()
        {

        }
    }
}
