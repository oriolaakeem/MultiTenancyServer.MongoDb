using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.hr
{
    public class HR_Branch : IEntityBase<ObjectId>
    {
        [Key]
        public ObjectId Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }

        [MaxLength(20)]
        public string HouseNo { get; set; }
        [MaxLength(20)]
        public string Street { get; set; }
        [MaxLength(20)]
        public string LGA { get; set; }
        [MaxLength(20)]
        public string State { get; set; }
        [MaxLength(20)]
        public string PhoneNo { get; set; }
        public string CreatedBy { get ; set; }
    }

}
