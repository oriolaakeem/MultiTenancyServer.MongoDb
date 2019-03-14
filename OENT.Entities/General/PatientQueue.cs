using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OryxDomainServices;
using System;

namespace OENT.Entities.General
{
    public class PatientQueue : IEntityBase<ObjectId>
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string PatientId { get; set; }
        public string Category { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime QueueDate { get; set; }
        public string FromTime { get; set; }
        public string ToTime { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime CreateDate { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime? UpdateDate { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime EffectiveDate { get; set; }
        public string Status { get; set; }
        public string UserSign { get; set; }
        public string CreatedBy { get; set; }
    }
}
