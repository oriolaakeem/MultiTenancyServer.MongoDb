using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.hr
{
    public class HR_ProfessionalTraining : IEntityBase<ObjectId>
    {
        [Key]
        public ObjectId Id { get; set; }


        public DateTime EffectiveDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }

        public string CreatedBy { get; set; }
        [MaxLength(50)]
        public string Body { get; set; }
        [MaxLength(50)]
        public string Certificate { get; set; }
        public DateTime DateIssued { get; set; }
        public DateTime ExpiryDate { get; set; }
        [MaxLength(100)]
        public int EmployeeId { get; set; }
    }
}

