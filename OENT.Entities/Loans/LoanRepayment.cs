using OENT.Entities.Common;
using OENT.Entities.StaffManagement;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OENT.Entities.Loans
{
    public class LoanRepayment : IEntityBase<ObjectId>
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }

        public ObjectId LoanId { get; set; }
        public ObjectId StaffAccountId { get; set; }
        public decimal PrincipalRepayment { get; set; }
        public decimal InterestRepayment { get; set; }
        public decimal MonthlyRepayment { get; set; }
        public DateTime NextDue { get; set; }
        public string Status
        {
            get { return PaymentStatus.ToString(); }
            private set { PaymentStatus = value.ParseEnum<PaymentStatus>(); }
        }
        [NotMapped]
        public PaymentStatus PaymentStatus { get; set; }

        public virtual Loan Loan { get; set; }
        public virtual StaffAccount StaffAccount { get; set; }
    }
}
