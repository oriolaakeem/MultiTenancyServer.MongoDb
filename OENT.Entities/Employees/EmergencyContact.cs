using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.Employees
{
    public class EmergencyContact : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Relationship { get; set; }
        public string TelephoneNo { get; set; }
        public string HouseNo { get; set; }
        public string Email { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime EffectiveDate { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime CreateDate { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime? UpdateDate { get; set; }
        public string Status { get; set; }
        public string UserSign { get; set; }
        public string EmployeeId { get; set; }
        public string CreatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTime? IEntityBase<ObjectId>.UpdateDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
