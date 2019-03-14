using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.Workflow
{

    public class HRWorkflowInstance : IEntityBase<ObjectId>
    {
        public HRWorkflowInstance()
        {
            StateApprovers = new HashSet<HRWorkflowInstanceState>();
            Notifiers = new HashSet<HRWorkflowInstanceNotifier>();
            Comments = new HashSet<HRWorkflowInstanceComment>();
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
        [MaxLength(50)]
        public string WorkflowId { get; set; }
        [Required]
        [MaxLength(50)]
        public string WorkflowSetupId { get; set; }
        [MaxLength(50)]
        public string ObjectId { get; set; }
        [MaxLength(250)]
        public string ObjectTypeInfo { get; set; }
        [Required]
        public string InvocationData { get; set; }
        [Required]
        public string Arguments { get; set; }
        [Required]
        public string ArgumentTypes { get; set; }
        [MaxLength(500)]
        public string FrontEndLink { get; set; }
        [Required]
        [MaxLength(50)]
        public string CurrentState { get; set; }
        [Required]
        [MaxLength(50)]
        public string CurrentApproverId { get; set; }
        [Required]
        [MaxLength(100)]
        public string CurrentApproverName { get; set; }
        [MaxLength(100)]
        public string MethodName { get; set; }
        public bool Completed { get; set; }
        [MaxLength(50)]
        public string EmployeeId { get; set; }
        [Required]
        [MaxLength(100)]
        public string EmployeeName { get; set; }
        [MaxLength(100)]
        public string EmployeeEmail { get; set; }
        [MaxLength(50)]
        public string EmployeeUserId { get; set; }
        [MaxLength(50)]
        public string ObjectCheckId { get; set; }
        public string WorkflowText { get; set; }
        [Required]
        public WorkflowObjectType ObjectType { get; set; }
        public ICollection<HRWorkflowInstanceState> StateApprovers { get; set; }
        public ICollection<HRWorkflowInstanceNotifier> Notifiers { get; set; }
        public ICollection<HRWorkflowInstanceComment> Comments { get; set; }
        public string CreatedBy { get; set; }
    }


}
