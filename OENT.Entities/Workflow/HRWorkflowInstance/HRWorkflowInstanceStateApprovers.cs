using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.Workflow
{

    public class HRWorkflowInstanceStateApprover : IEntityBase<ObjectId>
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
        [MaxLength(50)]
        public string ApproverId { get; set; }
        [Required]
        [MaxLength(100)]
        public string ApproverName { get; set; }
        [Required]
        [MaxLength(100)]
        public string ApproverEmail { get; set; }
        [Required]
        [MaxLength(50)]
        public string ApproverUserId { get; set; }
        public ObjectId HRWorkflowInstanceStateId { get; set; }
        public string CreatedBy { get; set; }
    }
}
