using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities
{

    public class WorkflowNextState : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }
        [Required]
        [StringLength(50)]
        public string WFTriggerId { get; set; }

        public ObjectId WorkFlowStateId { get; set; }
        [Required]
        [MaxLength(50)]
        public string NextState { get; set; }
        public string CreatedBy { get; set; }
    }

}
