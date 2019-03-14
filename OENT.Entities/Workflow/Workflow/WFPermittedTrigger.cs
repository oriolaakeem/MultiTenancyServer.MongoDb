using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OENT.Entities
{
    public class WFPermittedTrigger : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        [StringLength(50)]
        public string WFTriggerId { get; set; }
        [Required]
        [MaxLength(50)]
        public ObjectId WFStateId { get; set; }
        [MaxLength(50)]
        public string NextState { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        [Required, MaxLength(50)]
        public string UserSign { get; set; }
        public string CreatedBy { get; set; }
    }

    [NotMapped]
    public class WFPermittedTriggerView : WFPermittedTrigger
    {

        public string NextStateName { get; set; }
        public string TriggerName { get; set; }

    }

}
