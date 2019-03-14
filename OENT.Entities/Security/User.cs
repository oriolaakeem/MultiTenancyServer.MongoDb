using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OENT.Entities
{
    [NotMapped]
    public class User : IEntityBase<ObjectId>
    {

        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Name
        {
            get; set;
        }
        [MaxLength(20)]
        public string Code { get; set; }
        [Key]
        public ObjectId Id
        {
            get; set;
        }

        public DateTime CreateDate
        {
            get; set;
        }

        public DateTime? UpdateDate
        {
            get; set;
        }

        public string UserSign
        {
            get; set;
        }
        public DateTime EffectiveDate { get; set; }
        public string Status { get; set; }
        public string Role { get; set; }
        public bool Admin { get; set; }
        public string UserName { get; set; }
        public string CreatedBy { get; set; }
    }


}
