using MongoDB.Bson;
using OryxDomainServices;
using System;

namespace OENT.Entities.General
{
    public class Todo : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string ModuleId { get; set; }
        public string Link { get; set; }
        public string AttachmentId { get; set; }
        public string LongDescription { get; set; }
        public DateTime DueDate { get; set; }
        public bool Recurring { get; set; }
        public bool Status { get; set; }
        public bool Reminder { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string UserSign { get; set; }
        public string CreatedBy { get; set; }
    }
}
