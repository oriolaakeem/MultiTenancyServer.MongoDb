using System;
using System.Collections.Generic;
using MongoDB.Bson;
using OryxDomainServices;
using OENT.Entities.Patients;

namespace OENT.Entities.CaseNotes
{
    public class CaseNote : IEntityBase<ObjectId>
    {
        public Patient Patient { get; set; }
        public ObjectId Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Status { get; set; }
        public string UserSign { get; set; }
        public ICollection<Vital> Vitals { get; set; }
        public string CreatedBy { get; set; }
    }
}
