using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OryxDomainServices;

namespace OENT.Entities.JobInfo
{
    public class TimeInfo : IEntityBase<ObjectId>
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
        public string WorkSchedule { get; set; }
        public string WorkScheduleId { get; set; }
        public string HolidayCalendar { get; set; }
        public int WorkHours { get; set; }
        public string LeaveAccountType { get; set; }
        public string LeaveAccountTypeId { get; set; }
        public string CreatedBy { get; set; }



    }
}
