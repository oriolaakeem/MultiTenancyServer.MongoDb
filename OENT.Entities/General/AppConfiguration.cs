using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.General
{

    public class AppConfiguration : IEntityBase<ObjectId>
    {
        public ObjectId Id { get; set; }
        public string Code { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }
        public int QueryVersion { get; set; }
        public int MenuVersion { get; set; }
        public int WorkflowVersion { get; set; }
        public int SecurityVersion { get; set; }
        public string CreatedBy { get; set; }
    }


}
