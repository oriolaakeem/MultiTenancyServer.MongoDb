using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.Workflow
{

    public class HRWorkflowState : IEntityBase<ObjectId>
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
        public bool Deadline { get; set; }
        [Required]
        [MaxLength(50)]
        public string WorkflowState { get; set; }
        public bool StartState { get; set; }
        public bool EndState { get; set; }
        [Required]
        public ApprovingType ApprovingType { get; set; }
        public StandardType StandardType { get; set; }
        public OrgUnitType OrgUnitType { get; set; }
        [MaxLength(50)]
        public string DynamicGroupId { get; set; }
        public ObjectId HRWorkflowSetupId { get; set; }
        public string CreatedBy { get; set; }
    }


}
