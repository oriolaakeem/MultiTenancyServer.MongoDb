using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OENT.Entities
{
    public class WorkflowGroupEmployee : IEntityBase<ObjectId>
    {

        public ObjectId Id { get; set; }
        public int EmployeeId { get; set; }
        [Required]
        public ObjectId WorkflowGroupId { get; set; }
        public WorkflowGroup WorkflowGroup { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [MaxLength(50)]
        public string UserSign { get; set; }
        public string CreatedBy { get; set; }
    }


    [NotMapped]
    public class WorkGroupEmployeeView : WorkflowGroupEmployee
    {
        public string WorkflowGroupName { get; set; }
        public string EmployeeName { get; set; }
    }
}
