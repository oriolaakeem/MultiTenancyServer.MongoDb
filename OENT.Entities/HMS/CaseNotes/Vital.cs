using MongoDB.Bson;
using OryxDomainServices;
using System;

namespace OENT.Entities.CaseNotes
{
    public class Vital : IEntityBase<ObjectId>
    {
        public DateTime Effective { get; set; }
        public ObjectId Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Status { get; set; }
        public string UserSign { get; set; }
        public string CreatedBy { get; set; }
    }
}