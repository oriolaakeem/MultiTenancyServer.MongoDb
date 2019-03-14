// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using OENT.Entities.CompanyInfo;
using System;
using System.Collections.Generic;

namespace IdentityServer4.MongoDB.Interfaces
{
    public interface IConfigurationDbContext : IDisposable
    {
        IEnumerable<Entities.Client> Clients { get; }
        IEnumerable<Company> Companies { get; }
        IEnumerable<Entities.IdentityResource> IdentityResources { get; }
        IEnumerable<Entities.ApiResource> ApiResources { get; }

        void AddClient(Entities.Client entity);

        void AddCompany(Company entity);

        void AddIdentityResource(Entities.IdentityResource entity);

        void AddApiResource(Entities.ApiResource entity);
        void RemoveClient(Entities.Client dbClient);
        void RemoveApiResource(Entities.ApiResource dbReource);
    }
}