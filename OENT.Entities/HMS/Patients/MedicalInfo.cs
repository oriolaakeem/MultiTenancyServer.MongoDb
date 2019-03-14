using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using OryxDomainServices;

namespace OENT.Entities.Patients
{
    public class MedicalInfo : IEntityBase<ObjectId>
    {
        public string PatientId { get; set; }
        public string Genotype { get; set; }
        public string BloogGroup { get; set; }
        public string Rhesus { get; set; }
        public string Weight { get; set; }
        public string Height { get; set; }
        public ObjectId Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
