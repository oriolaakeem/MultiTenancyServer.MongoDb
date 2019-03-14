using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OENT.Entities.CompanyInfo;
using OENT.Entities.Loans;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace OENT.Entities.StaffManagement
{
    public class StaffLoanAccount : IEntityBase<ObjectId>
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }

        public ObjectId StaffAccountId { get; set; }

        public ObjectId LoanId { get; set; }

        public decimal Principal { get; set; }

        public decimal TotalRepayment { get; set; }

        public decimal AvailableBalance { get; set; }

        public ObjectId CompanyId { get; set; }

        public virtual StaffAccount StaffAccount { get; set; }
        public virtual Loan Loan { get; set; }
        public virtual Company Company { get; set; }
    }
}
