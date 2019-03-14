using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace OENT.Entities.Loans
{
    public class Tenure : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string Name { get; set; }
        public int NumberInMonths { get; set; }
    }
}
