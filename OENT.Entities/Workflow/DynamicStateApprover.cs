using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.Workflow
{

    public class DynamicStateApprover : IEntityBase<ObjectId>
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
        public string WorkflowStateId { get; set; }
        [StringLength(50)]
        public string ApproverId { get; set; }
        public string HRWorkflowGroupId { get; set; }
        [Required]
        public WorkflowGroupAssignBy AssignBy { get; set; }
        [Required]
        public string ModuleId { get; set; }
        [Required]
        public int DocNum { get; set; }
        [Required]
        public string DocId { get; set; }
        public string CreatedBy { get; set; }
    }

}
