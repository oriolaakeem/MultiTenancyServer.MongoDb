using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace OENT.Entities.Employees
{
    public class NoKInfo
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Occupation { get; set; }
        public string Relationship { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime EffectiveDate { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime CreateDate { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime? UpdateDate { get; set; }
        public string Status { get; set; }
        public string UserSign { get; set; }
        public string EmployeeId { get; set; }
    }


}
