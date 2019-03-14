using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OENT.Entities
{
    public class HRWorkflowStateApprover : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string WorkflowStateId { get; set; }
        [StringLength(50)]
        public string EmployeeId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [MaxLength(50)]
        public string UserSign { get; set; }
        public ObjectId HRWorkflowGroupId { get; set; }
        [Required]
        public WorkflowGroupAssignBy AssignBy { get; set; }
        [NotMapped]
        public string EmployeeName { get; set; }
        [NotMapped]
        public string WorkflowStateName { get; set; }
        [NotMapped]
        public Boolean StartState { get; set; }
        [NotMapped]
        public Boolean EndState { get; set; }
        public string CreatedBy { get; set; }
    }

    //[NotMapped]
    //public class HRWorkflowStateApproverView: HRWorkflowStateApprover
    //{
    //    public string EmployeeName { get; set; }
    //    public string WorkflowStateName { get; set; }
    //    public Boolean StartState { get; set; }
    //    public Boolean EndState { get; set; }
    //}
}
