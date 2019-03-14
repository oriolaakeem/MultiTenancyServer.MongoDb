using System;
using OryxDomainServices;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace OENT.Entities
{
    public class ApprovalHistory : IEntityBase<ObjectId>
    {
        [Key]
        public ObjectId Id { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
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
        [Required]
        [MaxLength(50)]
        public string ApprovalStatus { get; set; }
        [Required]
        [MaxLength(50)]
        public string PreviousStatus { get; set; }
        [Required]
        [MaxLength(50)]
        public string WorkflowId { get; set; }
        [MaxLength(254)]
        public string ApproverName { get; set; }
        public string CreatedBy { get; set; }
    }

}
