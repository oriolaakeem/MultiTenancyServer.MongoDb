using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.General
{
    public class AssociationTypeLog : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        [Required]
        public string ParentType { get; set; }
        [Required]
        public string ChildType { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Status { get; set; }
        public string UserSign { get; set; }
        public int LogInstance { get; set; }
        public string CreatedBy { get; set; }
    }
}
