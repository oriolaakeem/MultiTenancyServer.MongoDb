using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OryxDomainServices;

namespace OENT.Entities.JobInfo
{
    public class OrganisationalInfo : IEntityBase<ObjectId>
    {

        public ObjectId Id { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime EffectiveDate { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime CreateDate { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime? UpdateDate { get; set; }
        public string Status { get; set; }
        public string UserSign { get; set; }

        public string EmployeeId { get; set; }
        public string Company { get; set; }
        public string Division { get; set; }
        public string BusinessUnit { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string Location { get; set; }
        public string Job { get; set; }
        public string JobId { get; set; }
        public string CreatedBy { get; set; }
    }

}
