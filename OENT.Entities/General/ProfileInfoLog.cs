using MongoDB.Bson;
using OSSO.DomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.General
{
    public class ProfileInfoLog : ILogEntityBase<ObjectId>, IEntityBase<ObjectId>
    {
        public int LogInstance { get; set; }
        public ObjectId Id { get; set; }
        public byte[] ProfilePic1 { get; set; }
        public byte[] ProfilePic2 { get; set; }
        public byte[] ProfilePic3 { get; set; }
        public byte[] ProfilePic4 { get; set; }
        public byte[] ProfilePic5 { get; set; }
        [MaxLength(50)]
        [Required]
        public DateTime EffectiveDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }
        [MaxLength(50)]
        [Required]
        public string EmployeeId { get; set; }
        [MaxLength(1000)]
        public string Introduction { get; set; }
        [MaxLength(1000)]
        public string CareerGoals { get; set; }
        [MaxLength(1000)]
        public ICollection<Hobby> Hobbies { get; set; }
        [MaxLength(1000)]
        public ICollection<Language> Languages { get; set; }
        [MaxLength(50)]
        public ICollection<Skill> Skills { get; set; }


    }
}
