using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OryxDomainServices;

namespace OENT.Entities.HMO.Tarriffs
{
    public class ServiceTariff : IEntityBase<ObjectId>
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public double Price { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string ServiceGroup { get; set; }
        public string ServiceCategory { get; set; }
    }
}

