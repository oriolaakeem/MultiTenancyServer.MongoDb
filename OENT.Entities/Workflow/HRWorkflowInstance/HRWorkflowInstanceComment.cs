using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.Workflow
{

    public class HRWorkflowInstanceComment : IEntityBase<ObjectId>
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
        [MaxLength(50)]
        public string SourceId { get; set; }
        public string InstanceId { get; set; }
        public CommentType CommentType { get; set; }
        public ObjectId HRWorkflowInstanceId { get; set; }
        [Required]
        public string Comment { get; set; }
        public string CreatedBy { get; set; }
    }
}
