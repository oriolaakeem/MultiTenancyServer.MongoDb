using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MongoDB.Bson;
using OryxDomainServices;

namespace OENT.Entities.Authorization
{
    public enum SecurableEnum
    {
        [DisplayName("Patients")]
        Patients = 0,
        [DisplayName("Employees")]
        Employees = 1,


    }

    public class Securable : IEntityBase<ObjectId>
    {
        public Securable()
        {
            AssignedPermissions = new HashSet<SecurablePermission>();
        }
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
        public string Name { get; set; }
        [Required]
        public SecurableEnum SecuredItem { get; set; }
        public ICollection<SecurablePermission> AssignedPermissions { get; set; }
        public string CreatedBy { get; set; }
    }

    public class SecurablePermission : IEntityBase<ObjectId>
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
        public ObjectId SecurableId { get; set; }
        public PermissionOption Permission { get; set; }
        public Boolean Assigned { get; set; }
        public string CreatedBy { get; set; }
    }

}
