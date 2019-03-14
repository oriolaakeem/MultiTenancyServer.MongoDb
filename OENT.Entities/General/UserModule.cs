using MongoDB.Bson;
using OryxDomainServices;
using System;

namespace OENT.Entities.General
{
    public class UserModule : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Icon { get; set; }
        public string Route { get; set; }
        public string Module { get; set; }
        public string Cardheader { get; set; }
        public string CssClass { get; set; }
        public string CssClasses { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Status { get; set; }
        public string UserSign { get; set; }
        public string CreatedBy { get; set; }
    }
}