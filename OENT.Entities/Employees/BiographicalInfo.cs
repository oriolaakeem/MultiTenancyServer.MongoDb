using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OryxDomainServices;

namespace OENT.Entities.Employees
{
    public class BiographicalInfo : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        public string Lga { get; set; }
        public string State { get; set; }
        public string GeoPoliticalZone { get; set; }
        public string Nationality { get; set; }
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
