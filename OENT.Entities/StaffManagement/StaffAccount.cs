using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using OENT.Entities.CompanyInfo;
using infusync.Security;
using OryxDomainServices;
using System;

namespace OENT.Entities.StaffManagement
{
    public class StaffAccount : IEntityBase<ObjectId>
    {
        [BsonId]
        [JsonConverter(typeof(ObjectIdConverter))]
        public ObjectId Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }

        public ObjectId CompanyId { get; set; }

        public string EmployeeNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string JobTitle { get; set; }
        public string EmailAddress { get; set; }
        public decimal GrossMonthlyPay { get; set; }
        public decimal CreditLimit { get; set; }
        public bool IsActive { get; set; }
        public bool IsBanned { get; set; }
        public bool IsTerminated { get; set; }
        public DateTime? DateTerminated { get; set; }
        public string BVN { get; set; }
        public string SalaryAccountName { get; set; }
        public string SalaryAccountNumber { get; set; }
        public string SalaryBankName { get; set; }

        public virtual Company Company { get; set; }
    }
}
