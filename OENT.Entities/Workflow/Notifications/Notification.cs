using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.Notifications
{
    public class Notification : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        public ObjectId MessageTemplateId { get; set; }
        [Required, MaxLength(250)]
        public string MessageTitle { get; set; }
        [Required, MaxLength(1000)]
        public string Message { get; set; }
        [MaxLength(50)]
        public string TransactionId { get; set; }
        [MaxLength(50)]
        public string ModuleId { get; set; }
        [MaxLength(250)]
        public string FrontEndPath { get; set; }
        [MaxLength(50)]
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Status { get; set; }
        public string UserSign { get; set; }
        public bool Read { get; set; }
        public string CreatedBy { get; set; }
    }

}
