using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.Workflow
{

    public class HRWorkflowInstanceState : IEntityBase<ObjectId>
    {
        public HRWorkflowInstanceState()
        {
            WorkflowStateApprovers = new HashSet<HRWorkflowInstanceStateApprover>();
        }
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
        public ApprovingType ApprovingType { get; set; }
        [Required]
        [MaxLength(50)]
        public string ApproverId { get; set; }
        public ObjectId HRWorkflowInstanceId { get; set; }
        [Required]
        [MaxLength(50)]
        public string WorkflowState { get; set; }
        public bool StartState { get; set; }
        public bool EndState { get; set; }
        public string Triggers { get; set; }
        public ICollection<HRWorkflowInstanceStateApprover> WorkflowStateApprovers { get; set; }
        public string CreatedBy { get; set; }
    }
}
