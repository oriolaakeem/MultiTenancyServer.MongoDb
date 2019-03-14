using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OryxDomainServices;

namespace OENT.Entities.Employees
{
    public class DependantInfo : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime EffectiveDate { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime CreateDate { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime? UpdateDate { get; set; }
        public string Status { get; set; }
        public string UserSign { get; set; }
        public string Address { get; set; }
        public string Relationship { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime BirthDate { get; set; }
        public string EmployeeId { get; set; }
        public string CreatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTime? IEntityBase<ObjectId>.UpdateDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

}

