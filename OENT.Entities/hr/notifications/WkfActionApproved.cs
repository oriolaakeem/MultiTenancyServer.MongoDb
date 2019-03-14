using System;
using OryxDomainServices;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;

namespace OENT.Entities.hr.notifications
{
    public class WkfActionApproved : IEntityBase<ObjectId>
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
        public string FormName { get; set; }
        [MaxLength(50)]
        public string EventReason { get; set; }
        [MaxLength(50)]
        public string Action { get; set; }
        public int CurrentOwnerID { get; set; }
        public int SubjectUserID { get; set; }
        public string CreatedBy { get; set; }
    }
}

