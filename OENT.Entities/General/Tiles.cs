using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.General
{

    public class Tile : IEntityBase<ObjectId>
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
        [MaxLength(200)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Image { get; set; }
        [MaxLength(200)]
        public string Link { get; set; }      
        [MaxLength(50)]
        public string SecurableId { get; set; }
        [MaxLength(50)]
        public string Module { get; set; }
        public int Position { get; set; }
        [MaxLength(50)]
        public string Section { get; set; }
        public string CreatedBy { get; set; }
    }

}
