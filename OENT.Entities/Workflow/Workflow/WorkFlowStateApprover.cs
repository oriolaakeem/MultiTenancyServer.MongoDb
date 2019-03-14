using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OENT.Entities
{
    public class WorkflowStateApprover : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        [Required]
        [MaxLength(50)]
        public ObjectId WorkflowStateId { get; set; }
        [StringLength(50)]
        public string EmployeeId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [MaxLength(50)]
        public string UserSign { get; set; }
        public ObjectId WorkflowGroupId { get; set; }
        public string CreatedBy { get; set; }
    }


    [NotMapped]
    public class WorkflowStateApproverView : WorkflowStateApprover
    {
        public string EmployeeName { get; set; }
        public string WorkflowStateName { get; set; }
    }
}
