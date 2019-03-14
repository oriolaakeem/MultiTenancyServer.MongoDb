using System;
using MongoDB.Bson;
using OryxDomainServices;

namespace OENT.Entities.HMO
{
    public class Change : IEntityBase<ObjectId>
    {
        public Change()
        {
        }

        public ObjectId Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
    }
}


