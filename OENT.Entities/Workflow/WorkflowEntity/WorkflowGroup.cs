using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OENT.Entities
{
    public class HRWorkflowGroup : IEntityBase<ObjectId>
    {

        public HRWorkflowGroup()
        {
            WorkflowStateApprovers = new HashSet<HRWorkflowStateApprover>();
            Assignees = new HashSet<HRWorkflowGroupEmployee>();
        }

        [Key]
        public ObjectId Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        [Required, MaxLength(50)]
        public string WorkflowId { get; set; }

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

        public virtual ICollection<HRWorkflowStateApprover> WorkflowStateApprovers { get; set; }
        public virtual ICollection<HRWorkflowGroupEmployee> Assignees
        {
            get; set;
        }
        public string CreatedBy { get; set; }
    }

   
    [NotMapped]
    public class HRWorkflowGroupView : HRWorkflowGroup
    {
        public string WorkflowName { get; set; }
        //public virtual ICollection<HRWorkflowStateApprover> WorkflowStateApproversView { get; set; }
    }

    public enum WorkflowGroupAssignBy
    {
        Employee = 0,
        Department = 1,
        Division = 2,
        BusinessUnit = 3,
        Company = 4,
        IncidentType = 5
    }
}
