using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.hr
{
    public class HR_Academic : IEntityBase<ObjectId>
    {
        [Key]
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

        [MaxLength(50)]
        public string Instituition { get; set; }
        public DateTime DateAdmitted { get; set; }
        public DateTime DateCompleted { get; set; }
        [MaxLength(50)]
        public string Course { get; set; }
        [MaxLength(50)]
        public string Qualification { get; set; }
        [MaxLength(50)]
        public string Grade { get; set; }

        public virtual HR_Award HR_Award { get; set; }
        public string CreatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }


}

