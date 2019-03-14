using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.JobInfo
{
    public class JobDes : IEntityBase<ObjectId>
    {

        [Key]
        public ObjectId Id { get; set; }
        [MaxLength(30)]
        public string JobDesCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string JobId { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }


        [MaxLength(255)]
        [Required]
        public string Objective { get; set; }

        [MaxLength(20)]
        [Required]
        public string ObjectiveStatus { get; set; }

        [MaxLength(255)]
        [Required]
        public string ObjectiveTarget { get; set; }


        public Decimal? ProbabilityOfSuccess { get; set; }

        [MaxLength(50)]
        public string Category { get; set; }
        public string CreatedBy { get; set; }

    }
}
