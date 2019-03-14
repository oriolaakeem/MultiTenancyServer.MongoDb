using System;
using MongoDB.Bson;
using OryxDomainServices;

namespace OENT.Entities.HMO.Enrollees
{
    public class Enrollee : IEntityBase<ObjectId>
    {
        public Enrollee()
        {
        }

        public ObjectId Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
