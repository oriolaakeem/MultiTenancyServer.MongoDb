using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OryxDomainServices;
using System;

namespace OENT.Entities.General
{

    public class Definition : IEntityBase<ObjectId>
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string JunctionObject
        {
            get;
            set;
        }
        public string Name { get; set; }
        public string Type
        {
            get;
            set;
        }
        public DateTime EffectiveDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Status { get; set; }
        public string UserSign { get; set; }
        public string CreatedBy { get; set; }
    }
}
