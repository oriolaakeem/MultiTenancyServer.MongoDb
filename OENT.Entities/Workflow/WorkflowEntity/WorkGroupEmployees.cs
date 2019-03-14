using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OENT.Entities
{
    public class HRWorkflowGroupEmployee : IEntityBase<ObjectId>
    {
        [Key]
        public ObjectId Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Assignee { get; set; }
        [MaxLength(200)]
        public string AssigneeName { get; set; }
        [Required]
        public ObjectId HRWorkflowGroupId { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [MaxLength(50)]
        public string UserSign { get; set; }
        [Required]
        public WorkflowGroupAssignBy AssignBy { get; set; }
        public string CreatedBy { get; set; }
    }


    [NotMapped]
    public class HRWorkGroupEmployeeView : HRWorkflowGroupEmployee
    {
        public string WorkflowGroupName { get; set; }
        public string EmployeeName { get; set; }
    }


}
