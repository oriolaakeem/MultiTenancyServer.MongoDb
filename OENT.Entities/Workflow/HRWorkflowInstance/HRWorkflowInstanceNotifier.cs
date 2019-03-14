using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.Workflow
{

    public class HRWorkflowInstanceNotifier : IEntityBase<ObjectId>
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
        public ApprovingType NotifierType { get; set; }
        [Required]
        [MaxLength(50)]
        public string NotifiedId { get; set; }
        [Required]
        [MaxLength(100)]
        public string NotifiedName { get; set; }
        [Required]
        [MaxLength(100)]
        public string NotifiedEmail { get; set; }
        [Required]
        [MaxLength(50)]
        public string NotifiedUserId { get; set; }
        public ObjectId HRWorkflowInstanceId { get; set; }
        public string CreatedBy { get; set; }
    }

}
