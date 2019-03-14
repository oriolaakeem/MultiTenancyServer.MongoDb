// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.MongoDB.Configuration;
using IdentityServer4.MongoDB.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using OENT.Entities.CompanyInfo;
using OryxDomainServices;
using System.Collections.Generic;

namespace IdentityServer4.MongoDB.DbContexts
{
    public class ConfigurationDbContext : MongoDBContextBase, IConfigurationDbContext
    {
        private IRepository<Entities.Client> _clients;
        private IRepository<Company> _companies;
        private IRepository<Entities.IdentityResource> _identityResources;
        private IRepository<Entities.ApiResource> _apiResources;

        public ConfigurationDbContext(IOptions<MongoDBConfiguration> settings,
            IRepository<Entities.Client> clients,
            IRepository<Company> companies,
            IRepository<Entities.IdentityResource> identityResources,
            IRepository<Entities.ApiResource> apiResources,
            IHostingEnvironment environment)
            : base(settings, environment)
        {
            _companies = companies;
            _clients = clients;
            _identityResources = identityResources;
            _apiResources = apiResources;
        }

        public IEnumerable<Entities.Client> Clients
        {
            get { return _clients.GetAll(); }
        }
        public IEnumerable<Entities.IdentityResource> IdentityResources
        {
            get { return _identityResources.GetAll(); }
        }

        public IEnumerable<Entities.ApiResource> ApiResources
        {
            get { return _apiResources.GetAll(); }
        }

        public IEnumerable<Company> Companies
        {
            get { return _companies.GetAll(); }
        }

        public void AddClient(Entities.Client entity)
        {
            _clients.Add(entity);
        }

        public void AddIdentityResource(Entities.IdentityResource entity)
        {
            _identityResources.Add(entity);
        }

        public void AddApiResource(Entities.ApiResource entity)
        {
            _apiResources.Add(entity);
        }

        public void RemoveClient(Entities.Client dbClient)
        {
            _clients.Remove(dbClient.Id);
        }

        public void RemoveApiResource(Entities.ApiResource dbReource)
        {
            _apiResources.Remove(dbReource.Id);
        }

        public void AddCompany(Company entity)
        {
            _companies.Add(entity);
        }
    }
}