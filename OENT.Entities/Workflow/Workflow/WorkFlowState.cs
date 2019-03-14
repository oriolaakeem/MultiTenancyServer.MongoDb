using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OENT.Entities
{
    public class WorkFlowState : IWorkflowState<ObjectId>

    {
        public WorkFlowState()
        {
            WorkflowNextStates = new HashSet<WorkflowNextState>();
        }

        [Key]
        public ObjectId Id { get; set; }
        [Required, MaxLength(50)]
        public string WFStateId { get; set; }
        [Required, MaxLength(1)]
        public string Status { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime? UpdateDate { get; set; }
        [Required, MaxLength(50)]
        public string UserSign { get; set; }
        public ObjectId WorkFlowId { get; set; }
        public bool StartState { get; set; }
        public bool EndState { get; set; }

        public virtual ICollection<WorkflowNextState> WorkflowNextStates { get; set; }
        public string CreatedBy { get; set; }

    }


    [NotMapped]
    public class WorkflowStateView : WorkFlowState
    {
        public string WFStateName { get; set; }
        public string NextStateName { get; set; }
        public string PermTriggerName { get; set; }
    }

    public interface IWorkflowState<ObjectId> : IEntityBase<ObjectId>
    {
        ObjectId WorkFlowId { get; set; }
        bool StartState { get; set; }
        bool EndState { get; set; }
        ICollection<WorkflowNextState> WorkflowNextStates { get; set; }
        string WFStateId { get; set; }
    }
}
