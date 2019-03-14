using OENT.Entities.StaffManagement;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace OENT.Entities.Loans
{
    public class InvoiceLineItem : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }

        public string Description { get; set; }
        public decimal Amount { get; set; }
        public ObjectId StaffAccountId { get; set; }
        public ObjectId InvoiceId { get; set; }
        public ObjectId LoanId { get; set; }

        public virtual Invoice Invoice { get; set; }

        public virtual StaffAccount StaffAccount { get; set; }
        public virtual Loan Loan { get; set; }
        DateTime? IEntityBase<ObjectId>.UpdateDate { get; set; }
    }
}
