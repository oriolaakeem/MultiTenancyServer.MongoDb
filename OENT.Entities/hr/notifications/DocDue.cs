using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using OryxDomainServices;

namespace OENT.Entities.hr.notifications
{
    public class DocDue : IEntityBase<ObjectId>
    {

        public ObjectId Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        public DateTime EffectiveDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }

        [MaxLength(100)]
        public string Subject { get; set; }
        [MaxLength(1000)]
        public string Body { get; set; }
        [MaxLength(10)]
        public string Priority { get; set; }
        [MaxLength(50)]
        public string DocName { get; set; }
        public DateTime DueOn { get; set; }
        public int DaysLeft { get; set; }
        public int SenderID { get; set; }
        [MaxLength(50)]
        public string Reciever { get; set; }
        [MaxLength(50)]
        public string DocURL { get; set; }
        public string CreatedBy { get; set; }
    }
}

