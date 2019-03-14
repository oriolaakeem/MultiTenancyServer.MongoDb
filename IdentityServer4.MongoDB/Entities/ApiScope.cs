// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer4.MongoDB.Entities
{
    public class ApiScope : Scope
    {
        public ApiScope(string name) : base(name) { }
        //public string Name { get; set; }
        //public string DisplayName { get; set; }
        //public string Description { get; set; }
        //public bool Required { get; set; }
        //public bool Emphasize { get; set; }
        //public bool ShowInDiscoveryDocument { get; set; } = true;
        //public List<ApiScopeClaim> UserClaims { get; set; }
    }
}