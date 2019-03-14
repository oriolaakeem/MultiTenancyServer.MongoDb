using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.hr
{
    public class HR_TaskAndTarget : IEntityBase<ObjectId>
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
        public string Target { get; set; }
        [MaxLength(255)]
        public string Activity { get; set; }
        public string CreatedBy { get ; set ; }
    }

}
