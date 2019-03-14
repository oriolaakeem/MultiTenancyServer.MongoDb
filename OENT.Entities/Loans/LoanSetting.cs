using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace OENT.Entities.Loans
{
    public class LoanSetting : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }

        public string Name { get; set; }
        public string Value { get; set; }
    }
}
