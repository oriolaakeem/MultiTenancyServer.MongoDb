using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using OryxDomainServices;

namespace OENT.Entities
{
    public class HRApprovalHistory : IEntityBase<ObjectId>
    {
        
        public ObjectId Id { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
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
        [MaxLength(50)]
        public string ApproverName { get; set; }
        [Required]
        [MaxLength(50)]
        public string ApprovalStatus { get; set; }
        [MaxLength(50)]
        public string ApprovalStatusName { get; set; }
        [Required]
        public WorkflowGroupAssignBy ApproveBy { get; set; }
        public string CreatedBy { get; set; }
    }
}
