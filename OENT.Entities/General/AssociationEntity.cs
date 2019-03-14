using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.General
{
    public class AssociationEntity : IEntityBase<ObjectId>
    {

        public ObjectId Id { get; set; }

        public string Name { get; set; }

        [MaxLength(20)]
        public string Code { get; set; }

        [Required]
        [MaxLength(50)]
        public string ParentId { get; set; }
        [MaxLength(200)]
        public string ParentName { get; set; }
        [Required]
        public string ParentType { get; set; }
        [Required]
        [MaxLength(50)]
        public string ChildId { get; set; }
        [MaxLength(200)]
        public string ChildName { get; set; }
        [Required]
        public string ChildType { get; set; }

        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Status { get; set; }
        public string UserSign { get; set; }
        public string CreatedBy { get; set; }
    }
}
