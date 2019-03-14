using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.Workflow
{

    public class HRWorkflowSetup : IEntityBase<ObjectId>
    {
        public HRWorkflowSetup()
        {
            HRWorkflowStates = new HashSet<HRWorkflowState>();
            HRWorkflowNotifiers = new HashSet<HRWorkflowNotifier>();
        }

        public ObjectId Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }
        [MaxLength(50)]
        public string WorkflowId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public ICollection<HRWorkflowState> HRWorkflowStates { get; set; }
        public ICollection<HRWorkflowNotifier> HRWorkflowNotifiers { get; set; }
        public string CreatedBy { get; set; }
    }
}

