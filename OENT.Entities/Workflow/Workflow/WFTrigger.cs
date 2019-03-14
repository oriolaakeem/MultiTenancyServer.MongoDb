using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities
{
    public class WFTrigger : IWFTrigger<ObjectId>
    {

        [Key]
        public ObjectId Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        public bool Active { get; set; }
        [Required, MaxLength(1)]
        public string Status { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [Required, MaxLength(50)]
        public string UserSign { get; set; }
        [Required]
        public Boolean IsSystem { get; set; }
        public string CreatedBy { get; set; }
    }

   
    public interface IWFTrigger<ObjectId> : IEntityBase<ObjectId>
    {
        bool Active { get; set; }
        Boolean IsSystem { get; set; }
    }
}
