using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities
{

    public class HRApprovalPath : IEntityBase<ObjectId>
    {
        public HRApprovalPath() => this.HRPathNextStates = new HashSet<HRApprovalPathNextState>();

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
        public string TransactionId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ModuleName { get; set; }
        [Required]
        [MaxLength(50)]
        public string ApproverId { get; set; }
        [MaxLength(100)]
        public string ApproverName { get; set; }
        [Required]
        [MaxLength(50)]
        public string ApprovalStatus { get; set; }
        [MaxLength(50)]
        public string ApprovalStatusName { get; set; }
        [Required]
        public WorkflowGroupAssignBy ApproveBy { get; set; }
        [MaxLength(250)]
        public string ApplicationLink { get; set; }
        public Boolean EndState { get; set; }
        public Boolean StartState { get; set; }
        public int StateOrder { get; set; }

        public ICollection<HRApprovalPathNextState> HRPathNextStates { get; set; }
        public string CreatedBy { get; set; }
    }


    public class HRApprovalPathNextState : IEntityBase<ObjectId>
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
        public string NextState { get; set; }
        [Required]
        [MaxLength(100)]
        public string NextStateName { get; set; }
        public Boolean EndState { get; set; }
        public ObjectId HRApprovalPathId { get; set; }
        public string CreatedBy { get; set; }
    }

}
