using System;
using MongoDB.Bson;
using OryxDomainServices;

namespace OENT.Entities.HMO.Plans
{
    public class PlanGroup : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
    }
}