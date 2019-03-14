using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using OryxDomainServices;

namespace OENT.Entities
{
    public class WFState : IEntityBase<ObjectId>
    {
        public WFState()
        {
            WFPermittedTriggers = new List<WFPermittedTrigger>();
        }


        [Key]
        public ObjectId Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }

        public virtual ICollection<WFPermittedTrigger> WFPermittedTriggers { get; set; }
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
}
