using MongoDB.Bson;
using OryxDomainServices;
using OENT.Entities.Authorization;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities
{

    public class RolePermission : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }
        [Required]
        [MaxLength(50)]
        public ObjectId RoleId { get; set; }
        [Required]
        public Permission Permission { get; set; }
        [Required]
        public string SecurableId { get; set; }
        [Required]
        public bool Assigned { get; set; }
        public string CreatedBy { get ; set; }
    }
}
