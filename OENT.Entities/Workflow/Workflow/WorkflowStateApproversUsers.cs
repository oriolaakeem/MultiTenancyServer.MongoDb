using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities
{
    public class WorkflowStateApproversUsers : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        [Required]
        [MaxLength(50)]
        public ObjectId WorkflowStateId { get; set; }
        [StringLength(50)]
        public string UserId { get; set; }
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

}
