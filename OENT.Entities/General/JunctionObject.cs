using MongoDB.Bson;
using OryxDomainServices;
using System;

namespace OENT.Entities.General
{
    public class JunctionObject : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string ParentType { get; set; }
        public string ParentName { get; set; }
        public string ChildType { get; set; }
        public string ChildName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Status { get; set; }
        public string UserSign { get; set; }
        public string CreatedBy { get; set; }
    }
}
