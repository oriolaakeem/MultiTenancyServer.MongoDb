using System;
using MongoDB.Bson;
using OryxDomainServices;

namespace OENT.Entities.HMO.Billings
{
    public class Bill : IEntityBase<ObjectId>
    {
        public Bill()
        {
        }

        public ObjectId Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
    }
}