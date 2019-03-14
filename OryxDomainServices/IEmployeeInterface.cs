using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OryxDomainServices
{
    public interface IEmployeeInterface<TId> : IEntityBase<TId>
    {
        string EmployeeId { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        DateTime EffectiveDate { get; set; }
    }
}