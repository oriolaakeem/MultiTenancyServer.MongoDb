using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.hr
{
    public class HR_Calendar : IEntityBase<ObjectId>
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        public string CreatedBy { get; set; }
    }
}

