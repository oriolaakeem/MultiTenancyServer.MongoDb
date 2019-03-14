using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OryxDomainServices;
using System;

namespace OENT.Entities.Patients
{
    public class HMOInformation : IEntityBase<ObjectId>
    {
        public string PatientId { get; set; }
        public string HMONO { get; set; }
        public string HMOName { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime ExpiryDate { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime JoinedDate { get; set; }
        public ObjectId Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
