using OENT.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace infusync.DataTier.Repository
{
    public interface IApplicationUserDbContext : IDisposable
    {
        IEnumerable<ApplicationUser> Users { get; }
        bool SupportsUserRole { get; }

        void AddApplicationUser(ApplicationUser entity);
        ApplicationUser AutoProvisionUser(string provider, string providerUserId, List<Claim> list);

        ApplicationUser FindByExternalProvider(string provider, string providerUserId);

        Task<ApplicationUser> GetUserById(string id);

        Task<ApplicationUser> GetUserByUsername(string username);
        bool ValidatePassword(string username, string plainTextPassword);
        Task<IList<string>> GetRoles(ApplicationUser user);
    }
}
