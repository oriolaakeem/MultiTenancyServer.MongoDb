// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.Collections.Generic;

namespace IdentityServer4.MongoDB.Entities
{
    public class ApiResource : Resource, IEntityBase<ObjectId>
    {
        public ApiResource() : base() { }

        public ObjectId Id { get; set; }
        //public bool Enabled { get; set; } = true;
        //public string Name { get; set; }
        //public string DisplayName { get; set; }
        //public string Description { get; set; }
        public List<ApiSecret> Secrets { get; set; }
        public List<ApiScope> Scopes { get; set; } = new List<ApiScope>();
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Status { get; set; }
        public string UserSign { get; set; }
        public string CreatedBy { get; set; }
        DateTime? IEntityBase<ObjectId>.UpdateDate { get; set; }
        //public List<ApiResourceClaim> UserClaims { get; set; }
    }
}
