using System;
using System.Collections.Generic;
using IdentityModel;
using IdentityServer4.Models;

namespace infusync.identity
{
    public class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                // custom identity resource with some consolidated claims
                new IdentityResource("custom.profile", new[] { JwtClaimTypes.Name, JwtClaimTypes.Email, JwtClaimTypes.Address, JwtClaimTypes.Role })
            };
        }
    }
}
