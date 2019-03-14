using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.hr
{
    public class HR_KPI : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }


        public int HR_TaskAndTarget { get; set; }
        [MaxLength(255)]
        public string TargetWeight { get; set; }
        [MaxLength(255)]
        public string ActivityWeight { get; set; }
        public string CreatedBy { get ; set ; }
    }

  
}
