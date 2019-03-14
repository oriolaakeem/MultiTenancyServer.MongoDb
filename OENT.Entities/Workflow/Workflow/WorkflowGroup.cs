using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OENT.Entities
{
    public class WorkflowGroup : IEntityBase<ObjectId>
    {

        public WorkflowGroup()
        {
            WorkflowStateApprovers = new HashSet<WorkflowStateApprover>();
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

        public virtual ICollection<WorkflowStateApprover> WorkflowStateApprovers { get; set; }
        public string CreatedBy { get; set; }
    }


    [NotMapped]
    public class WorkflowGroupView : WorkflowGroup
    {
        public string WorkflowName { get; set; }
    }
}
