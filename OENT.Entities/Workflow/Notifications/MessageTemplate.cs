using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OENT.Entities.Notifications
{
    public class MessageTemplate : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        [Required, StringLength(150)]
        public string MessageTitle { get; set; }
        public string MessageType { get; set; }
        public string MessageData { get; set; }
        public string DefaultMessage { get; set; }
        [MaxLength(200)]
        public string ClassName { get; set; }
        public int Frequency { get; set; }
        public string ModuleId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Status { get; set; }
        public string UserSign { get; set; }
        public int Version { get; set; }
        [NotMapped]
        public string TemplateFile { get; set; }
        public string CreatedBy { get; set; }
    }
}
