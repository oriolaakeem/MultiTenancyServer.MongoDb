using OENT.Entities.CompanyInfo;
using OENT.Entities.StaffManagement;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace OENT.Entities.Loans
{
    public class Loan : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }

        public decimal LoanPrincipal { get; set; }

        public int TenureId { get; set; }

        public decimal InterestRate { get; set; }

        public ObjectId StaffAccountId { get; set; } //Borrower

        public ObjectId CompanyId { get; set; }

        public virtual Tenure Tenure { get; set; }
        public virtual StaffAccount StaffAccount { get; set; }
        public virtual Company Company { get; set; }
    }
}
