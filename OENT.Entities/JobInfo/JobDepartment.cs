using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.JobInfo
{
    public class JobDepartment : IEntityBase<ObjectId>
    {

        public ObjectId Id { get; set; }
        public ObjectId HR_JobId { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }
        [Required]
        [MaxLength(50)]
        public string DepartmentId { get; set; }
        [MaxLength(200)]
        public string DepartmentName { get; set; }
        public string CreatedBy { get; set; }
    }

}
