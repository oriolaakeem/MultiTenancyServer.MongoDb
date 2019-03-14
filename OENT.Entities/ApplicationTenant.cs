using System;
using MongoDB.Bson;
using MultiTenancyServer;
namespace OENT.Entities
{
    public class ApplicationTenant : TenancyTenant<ObjectId>
    {
        public string DisplayName { get; set; }
    }
}
