using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace OENT.Entities.hr
{
    public class HR_Award : IEntityBase<ObjectId>
    {
        [Key]
        public ObjectId Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }

        public string Institution { get; set; }
        public string Employee { get; set; }
        public DateTime Year { get; set; }
        public string CreatedBy { get; set ; }
    }
}
