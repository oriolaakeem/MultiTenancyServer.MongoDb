using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.hr
{
    public class HR_Training : IEntityBase<ObjectId>
    {

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
        [MaxLength(20)]
        public string TrainingTypes { get; set; }
        [MaxLength(50)]
        public string Instituition { get; set; }
        public DateTime DateStarted { get; set; }
        public DateTime DateCompleted { get; set; }
        [MaxLength(50)]
        public string Course { get; set; }
        [MaxLength(50)]
        public string Certificate { get; set; }
        public string CreatedBy { get; set ; }
    }
}
