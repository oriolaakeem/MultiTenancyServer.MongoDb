using MongoDB.Bson;
using Newtonsoft.Json;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.General
{
    public class Module : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        [MaxLength(100)]
        public string Application { get; set; }
        [Required, MaxLength(1)]
        public string Status { get; set; }

        [Required]
        public DateTime EffectiveDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [Required, MaxLength(50)]
        public string UserSign { get; set; }
        [Required]
        public Boolean IsSystem { get; set; }
        public string CreatedBy { get; set; }
    }
}