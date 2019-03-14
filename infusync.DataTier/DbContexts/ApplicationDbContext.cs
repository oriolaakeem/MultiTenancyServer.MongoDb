using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Extensions;
using IdentityServer4.EntityFramework.Options;
using IdentityServer4.MongoDB.Entities;
using IdentityServer4.MongoDB.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MultiTenancyServer;
using MultiTenancyServer.EntityFramework;
using MultiTenancyServer.Options;
using OENT.Entities;
using OENT.Entities.CompanyInfo;

namespace infusync.DataTier.DbContexts
{
    public class ApplicationDbContext :
        IdentityDbContext<IdentityUser>,
        IConfigurationDbContext, IPersistedGrantDbContext,
        ITenantDbContext<ApplicationTenant, ObjectId>
    {
        private static object _tenancyModelState;
        private readonly ITenancyContext<ApplicationTenant> _tenancyContext;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            ITenancyContext<ApplicationTenant> tenancyContext)
            : base(options)
        {
            _tenancyContext = tenancyContext;
        }

        public IEnumerable<Client> Clients { get; set; }

        public IEnumerable<IdentityResource> IdentityResources { get; set; }

        public IEnumerable<ApiResource> ApiResources { get; set; }

        public IQueryable<PersistedGrant> PersistedGrants { get; set; }

        public IEnumerable<IdentityServer4.EntityFramework.Entities.DeviceFlowCodes> DeviceFlowCodes { get; set; }

        public DbSet<ApplicationTenant> Tenants { get; set; }

        public IEnumerable<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            var configurationStoreOptions = new ConfigurationStoreOptions();
            builder.ConfigureClientContext(configurationStoreOptions);
            builder.ConfigureResourcesContext(configurationStoreOptions);

            var operationalStoreOptions = new OperationalStoreOptions();
            builder.ConfigurePersistedGrantContext(operationalStoreOptions);

            var tenantStoreOptions = new TenantStoreOptions();
            builder.ConfigureTenantContext<ApplicationTenant, ObjectId>(tenantStoreOptions);

            var tenantReferenceOptions = new TenantReferenceOptions();
            builder.HasTenancy<string>(tenantReferenceOptions, out _tenancyModelState);

            builder.Entity<ApplicationTenant>(b =>
            {
                b.Property(t => t.DisplayName).HasMaxLength(256);
            });

            // Configure properties on User (ASP.NET Core Identity).
            builder.Entity<ApplicationUser>(b =>
            {
                // Add multi-tenancy support to entity.
                b.HasTenancy(() => _tenancyContext.Tenant.Id, _tenancyModelState, hasIndex: false);
                // Remove unique index on NormalizedUserName.
                b.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique(false);
                // Add unique index on TenantId and NormalizedUserName.
                b.HasIndex(tenantReferenceOptions.ReferenceName, nameof(ApplicationUser.NormalizedUserName))
                    .HasName("TenantUserNameIndex").IsUnique();
            });

            // Configure properties on Role (ASP.NET Core Identity).
            builder.Entity<ApplicationRole>(b =>
            {
                // Add multi-tenancy support to entity.
                b.HasTenancy(() => _tenancyContext.Tenant.Id, _tenancyModelState, hasIndex: false);
                // Remove unique index on NormalizedName.
                b.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique(false);
                // Add unique index on TenantId and NormalizedName.
                b.HasIndex(tenantReferenceOptions.ReferenceName, nameof(ApplicationRole.NormalizedName))
                    .HasName("TenantRoleNameIndex").IsUnique();
            });

            builder.Entity<Client>(b =>
            {
                b.HasTenancy(() => _tenancyContext.Tenant.Id, _tenancyModelState, hasIndex: false);
                b.HasIndex(c => c.ClientId).IsUnique(false);
                b.HasIndex(tenantReferenceOptions.ReferenceName, nameof(Client.ClientId)).IsUnique();
            });

            builder.Entity<IdentityResource>(b =>
            {
                b.HasTenancy(() => _tenancyContext.Tenant.Id, _tenancyModelState, hasIndex: false);
                b.HasIndex(r => r.Id).IsUnique(false);
                b.HasIndex(tenantReferenceOptions.ReferenceName, nameof(IdentityResource.Id)).IsUnique();
            });

            builder.Entity<ApiResource>(b =>
            {
                b.HasTenancy(() => _tenancyContext.Tenant.Id, _tenancyModelState, hasIndex: false);
                b.HasIndex(r => r.Id).IsUnique(false);
                b.HasIndex(tenantReferenceOptions.ReferenceName, nameof(ApiResource.Id)).IsUnique();
            });

            builder.Entity<ApiScope>(b =>
            {
                b.HasTenancy(() => _tenancyContext.Tenant.Id, _tenancyModelState, hasIndex: false);
                b.HasIndex(s => s).IsUnique(false);
                b.HasIndex(tenantReferenceOptions.ReferenceName, nameof(ApiScope)).IsUnique();
            });

            builder.Entity<PersistedGrant>(b =>
            {
                b.HasTenancy(() => _tenancyContext.Tenant.Id, _tenancyModelState, indexNameFormat: $"IX_{nameof(PersistedGrant)}_{{0}}");
            });

            builder.Entity<IdentityServer4.EntityFramework.Entities.DeviceFlowCodes>(b =>
            {
                b.HasTenancy(() => _tenancyContext.Tenant.Id, _tenancyModelState, hasIndex: false);
                b.HasIndex(c => c.DeviceCode).IsUnique(false);
                b.HasIndex(tenantReferenceOptions.ReferenceName, nameof(IdentityServer4.EntityFramework.Entities.DeviceFlowCodes.DeviceCode)).IsUnique();
            });
        }

        public Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.EnsureTenancy(_tenancyContext?.Tenant?.Id, _tenancyModelState);
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken)
        {
            this.EnsureTenancy(_tenancyContext?.Tenant?.Id, _tenancyModelState);
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public new Task Add(IdentityServer4.MongoDB.Entities.PersistedGrant entity)
        {
            throw new NotImplementedException();
        }

        public new Task Update(Expression<Func<IdentityServer4.MongoDB.Entities.PersistedGrant, bool>> filter, IdentityServer4.MongoDB.Entities.PersistedGrant entity)
        {
            throw new NotImplementedException();
        }

        public new Task Remove(Expression<Func<IdentityServer4.MongoDB.Entities.PersistedGrant, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task RemoveExpired()
        {
            throw new NotImplementedException();
        }

        public void AddClient(IdentityServer4.MongoDB.Entities.Client entity)
        {
            throw new NotImplementedException();
        }

        public void AddCompany(Company entity)
        {
            throw new NotImplementedException();
        }

        public void AddIdentityResource(IdentityServer4.MongoDB.Entities.IdentityResource entity)
        {
            throw new NotImplementedException();
        }

        public void AddApiResource(IdentityServer4.MongoDB.Entities.ApiResource entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveClient(IdentityServer4.MongoDB.Entities.Client dbClient)
        {
            throw new NotImplementedException();
        }

        public void RemoveApiResource(IdentityServer4.MongoDB.Entities.ApiResource dbReource)
        {
            throw new NotImplementedException();
        }
    }
}
