using MongoDB.Bson;
using OENT.Entities.Common;
using OENT.Entities.Enums;
using OENT.Entities.StaffManagement;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OENT.Entities.CompanyInfo
{
    public class Company : IEntityBase<ObjectId>
    {
        public Company()
        {
            StaffAccounts = new HashSet<StaffAccount>();
        }
        public ObjectId Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }

        public string RCNumber { get; set; }
        public string TIN { get; set; }
        public string CompanyName { get; set; }
        public string HeadOfficeLocation { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactMiddleName { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhone { get; set; }
        public string Status
        {
            get { return CompanyStatus.ToString(); }
            private set { CompanyStatus = value.ParseEnum<CompanyStatus>(); }
        }
        [NotMapped]
        public CompanyStatus CompanyStatus { get; set; }
        public byte[] Logo { get; set; }
        public string ImageExtension { get; set; }

        public virtual ICollection<StaffAccount> StaffAccounts { get; set; }
    }
}
