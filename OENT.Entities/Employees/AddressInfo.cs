using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OryxDomainServices;
using System;

namespace OENT.Entities.Employees
{
    public class AddressInfo : IEntityBase<ObjectId>
    {
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime EffectiveDate { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime CreateDate { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime? UpdateDate { get; set; }
        public string Status { get; set; }
        public string UserSign { get; set; }
        public string HouseNo { get; set; }
        public string Street { get; set; }
        public string Lga { get; set; }
        public string State { get; set; }
        public string AddressType { get; set; }
        public string PhoneNo { get; set; }
        public string EmployeeId { get; set; }
        public ObjectId Id { get; set; }
        public string CreatedBy { get; set; }
    }
}

