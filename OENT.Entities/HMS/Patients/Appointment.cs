using MongoDB.Bson;
using OryxDomainServices;
using System;

namespace OENT.Entities.Patients
{
    public class Appointment : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        public virtual ObjectId PatientId { get; set; }
        public virtual ObjectId DepartmentId { get; set; }
        public virtual ObjectId DoctorId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Patient { get; set; }
        public string Department { get; set; }
        public string Employee { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set;  }
        public DateTime EffectiveDate { get; set; }
        public string UserSign { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
    }
}
