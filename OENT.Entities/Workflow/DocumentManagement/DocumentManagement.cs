using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using OryxDomainServices;

namespace OENT.Entities
{

    public class DocumentManagement : IEntityBase<ObjectId>
    {
     
        public ObjectId Id { get; set; }
        [MaxLength(250)]
        public string FileType { get; set; }
        public string FileName { get; set; }
        public string FileVersion { get; set; }
        public string Size { get; set; }
        public string ObjectType { get; set; }
        public string ObjectId { get; set; }
        public byte[] Document { get; set; }
        public string DocumentString { get; set; }
        public string Description { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }
        public string PublishedBy { get; set; }
        public DateTime PublishedOn { get; set; }
        public string CreatedBy { get; set; }
    }

   
}
