using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OryxDomainServices;

namespace OENT.Entities.JobInfo
{
    public class JobInfo : IEntityBase<ObjectId>
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

        public string FileNo1 { get; set; }
        public string FileNo2 { get; set; }
        public string FileNo3 { get; set; }
        public string FileNo4 { get; set; }
        public string FileNo5 { get; set; }

        public string ManagerId { get; set; }

        public string ManagerName { get; set; }
        public string Grade { get; set; }
        public string PayStep { get; set; }
        public string Step { get; set; }
        public string Job { get; set; }
        public string EmploymentType { get; set; }
        public string EmploymentTypeId { get; set; }
        public bool CEO { get; set; }
        public string CreatedBy { get; set; }
    }




}
