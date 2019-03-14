using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OryxDomainServices;
using System;
using System.Collections.Generic;

namespace OENT.Entities.Employees
{
    public class ProfileInfo : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        public byte[] ProfilePic1 { get; set; }
        public byte[] ProfilePic2 { get; set; }
        public byte[] ProfilePic3 { get; set; }
        public byte[] ProfilePic4 { get; set; }
        public byte[] ProfilePic5 { get; set; }

        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime EffectiveDate { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime CreateDate { get; set; }
        [BsonDateTimeOptions(Representation = BsonType.Document, Kind = DateTimeKind.Local)]
        public DateTime? UpdateDate { get; set; }
        public string Status { get; set; }
        public string UserSign { get; set; }
        public string EmployeeId { get; set; }
        public string Introduction { get; set; }
        public string CareerGoals { get; set; }
        public ICollection<Hobby> Hobbies { get; set; }
        public ICollection<Language> Languages { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public string CreatedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        DateTime? IEntityBase<ObjectId>.UpdateDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
   
}

