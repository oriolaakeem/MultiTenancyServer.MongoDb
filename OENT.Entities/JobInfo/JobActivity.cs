using System;
using System.ComponentModel.DataAnnotations;
using OryxDomainServices;
using MongoDB.Bson;

namespace OENT.Entities.JobInfo
{
    public class JobActivity : IEntityBase<ObjectId>
    {


        [Key]
        public ObjectId Id { get; set; }
        [Required]
        [MaxLength(100)]
        public DateTime EffectiveDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }

        [MaxLength(100)]
        public string JobDesId { get; set; }
        [MaxLength(255)]
        public string Activity { get; set; }

        [Required]
        [MaxLength(50)]
        public string EmployeeId { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? DueDate { get; set; }

        public bool TaskCompleted { get; set; }
        public string CreatedBy { get; set; }
    }
}
