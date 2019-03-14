using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.Employees
{
    public class Language : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime EffectiveDate { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime CreateDate { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime? UpdateDate { get; set; }
        public string Status { get; set; }
        [MaxLength(50)]
        public string UserSign { get; set; }
        [MaxLength(50)]
        public string EmployeeId { get; set; }
        public string CreatedBy { get; set; }
        DateTime? IEntityBase<ObjectId>.UpdateDate { get; set ; }
    }

}
