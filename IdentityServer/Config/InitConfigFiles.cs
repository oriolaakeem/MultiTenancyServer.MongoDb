using IdentityServer4.Models;
using IdentityServer4.MongoDB.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using OENT.Entities.CompanyInfo;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ApplicationHost.Configuration
{
    public class InitConfigFiles : IInitConfigFiles
    {
        private readonly IConfigurationDbContext _context;
        //private readonly ApplicationDbContext _appContext;
        private IHostingEnvironment _env;

        public InitConfigFiles(IConfigurationDbContext context, IHostingEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public void InitializeFiles()
        {
            string contentRootPath = string.Empty;
            var clientJson = string.Empty;
            var apiresourceJson = string.Empty;
            if (_env.IsDevelopment())
            {
                contentRootPath = _env.ContentRootPath;
                clientJson = File.ReadAllText(contentRootPath + "/Config/clients.json");
                apiresourceJson = File.ReadAllText(contentRootPath + "/Config/apiresources.json");
            }
            else
            {
                contentRootPath = _env.ContentRootPath;
                clientJson = File.ReadAllText(contentRootPath + "/Config/azureclient.json");
                apiresourceJson = File.ReadAllText(contentRootPath + "/Config/apiresources.json");
            }

            var clients = JsonConvert.DeserializeObject<IEnumerable<IdentityServer4.MongoDB.Entities.Client>>(clientJson);
            var resources = JsonConvert.DeserializeObject<IEnumerable<IdentityServer4.MongoDB.Entities.ApiResource>>(apiresourceJson);

            bool lAdd = false;
            IList<IdentityServer4.MongoDB.Entities.Client> clientsToAdd = new List<IdentityServer4.MongoDB.Entities.Client>();

            foreach (var client in clients)
            {
                var dbClient = _context.Clients
                    .Where(c => c.ClientId == client.ClientId)
                    //.Include(p => p.Properties)
                    .FirstOrDefault();

                if (dbClient == null)
                {
                    lAdd = true;
                    clientsToAdd.Add(client);
                }
                else
                {
                    if (dbClient.Properties.Count > 0)
                    {
                        int.TryParse(dbClient.Properties.FirstOrDefault(c => c.Key == "version").Value, out int dbVersion);
                        int.TryParse(client.Properties.FirstOrDefault(c => c.Key == "version").Value, out int version);
                        if (dbVersion < version)
                        {
                            _context.RemoveClient(dbClient);
                            //_context.SaveChanges();
                            lAdd = true;
                            clientsToAdd.Add(client);
                        }
                    }
                    else
                    {
                        _context.RemoveClient(dbClient);
                        //_context.SaveChanges();
                        lAdd = true;
                        clientsToAdd.Add(client);
                    }
                }
            }

            foreach (var item in clientsToAdd)
            {
                List<IdentityServer4.MongoDB.Entities.ClientSecret> secrets = new List<IdentityServer4.MongoDB.Entities.ClientSecret>()
                {
                   new IdentityServer4.MongoDB.Entities.ClientSecret { Value = "F621F470-9731-4A25-80EF-67A6F7C5F4B8".Sha256() }
                };
                item.ClientSecrets = secrets;
                /*
                 * 
                 item.AllowedGrantTypes = new List<string>() {
                        GrantType.ResourceOwnerPassword,
                        GrantType.Implicit,
                        GrantType.ClientCredentials
                };
                item.AllowAccessTokensViaBrowser = true;
                item.AlwaysIncludeUserClaimsInIdToken = true;
                item.AlwaysSendClientClaims = true;
                item.AccessTokenType = (int)AccessTokenType.Jwt;
                item.AlwaysIncludeUserClaimsInIdToken = true;
                item.RequireConsent = false;
                item.RefreshTokenExpiration = 1;// IdentityServer4.Models.TokenExpiration.Absolute;

                */
                _context.AddClient(item);
            }
            //_context.SaveChanges();

            if (!_context.IdentityResources.Any())
            {
                foreach (var resource in infusync.identity.Resources.GetIdentityResources())
                {
                    _context.AddIdentityResource(new IdentityServer4.MongoDB.Entities.IdentityResource() { Name = resource.Name });
                }
                //_context.SaveChanges();
            }

            IList<IdentityServer4.MongoDB.Entities.ApiResource> resourcesToAdd = new List<IdentityServer4.MongoDB.Entities.ApiResource>();
            foreach (var resource in resources)
            {
                var dbReource = _context.ApiResources
                    .FirstOrDefault(c => c.Name == resource.Name);

                List<IdentityServer4.MongoDB.Entities.ApiSecret> secrets = new List<IdentityServer4.MongoDB.Entities.ApiSecret>()
                    {
                       new IdentityServer4.MongoDB.Entities.ApiSecret { Value = "F621F470-9731-4A25-80EF-67A6F7C5F4B8".Sha256() }
                    };

                if (dbReource != null)
                {
                    if (lAdd)
                    {
                        dbReource.Secrets = secrets;
                        _context.RemoveApiResource(dbReource);
                        // _context.SaveChanges();
                        resourcesToAdd.Add(resource);
                    }
                }
                else
                {

                    resource.Secrets = secrets;
                    resourcesToAdd.Add(resource);
                }
            }

            foreach (var item in resourcesToAdd)
            {
                _context.AddApiResource(item);
            }
            //_context.SaveChanges();

            if (!_context.Companies.Any())
            {
                _context.AddCompany
                    (
                        new Company()
                        {
                            ContactEmail = "admin@outlook.com",
                            CompanyName = "Individual",
                            ContactFirstName = "",
                            ContactLastName = "",
                            ContactPhone = "",
                            Id = new MongoDB.Bson.ObjectId("5bc22641aff0d92d64f1aba6")
                        }
                    );
                //_context.SaveChanges();
            }
        }
    }
    public interface IInitConfigFiles
    {
        void InitializeFiles();
    }
}
