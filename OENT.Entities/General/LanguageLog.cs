using MongoDB.Bson;
using OSSO.DomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.General
{
    public class LanguageLog : ILogEntityBase<ObjectId>, IEntityBase<ObjectId>
    {
        public int LogInstance { get; set; }
        public ObjectId Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }
    }
}
