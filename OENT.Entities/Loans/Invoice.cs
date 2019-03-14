using OENT.Entities.Common;
using OENT.Entities.CompanyInfo;
using OENT.Entities.Enums;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using MongoDB.Bson;

namespace OENT.Entities.Loans
{
    public class Invoice : IEntityBase<ObjectId>
    {
        public Invoice()
        {
            InvoiceLineItems = new HashSet<InvoiceLineItem>();
        }
        public ObjectId Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }

        public long RecordId { get; set; }

        public string InvoiceNum { get; set; }

        public ObjectId CompanyId { get; set; }

        public decimal GrandTotal { get; set; }

        public string Comment { get; set; }
        public string Status
        {
            get { return InvoiceStatus.ToString(); }
            private set { InvoiceStatus = value.ParseEnum<InvoiceStatus>(); }
        }

        [NotMapped]
        public InvoiceStatus InvoiceStatus { get; set; }

        public virtual ICollection<InvoiceLineItem> InvoiceLineItems { get; set; }
        public virtual Company Company { get; set; }
    }
}
