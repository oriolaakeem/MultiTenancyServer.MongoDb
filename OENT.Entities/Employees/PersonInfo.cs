using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OryxDomainServices;

namespace OENT.Entities.Employees
{
    public class PersonInfo : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string MaritalStatus { get; set; }
        public int NChildren { get; set; }
        public string BloodGroup { get; set; }
        public string Genotype { get; set; }
        public string NextOfKin { get; set; }
        public string AddressOfNextOfKin { get; set; }
        public string PhoneNoOfNextOfKin { get; set; }
        public string RelationshipWithNextOfKin { get; set; }
        public string MaidenName { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime BirthDate { get; set; }
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
