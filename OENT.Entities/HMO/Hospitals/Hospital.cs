using System;
using MongoDB.Bson;
using OryxDomainServices;

namespace OENT.Entities.HMO.Hospitals
{
    public class Hospital : IEntityBase<ObjectId>
    {
        public Hospital()
        {
        }

        public ObjectId Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
    }
}