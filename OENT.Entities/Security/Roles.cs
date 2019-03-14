using MongoDB.Bson;
using OryxDomainServices;
using OENT.Entities.Authorization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OENT.Entities
{

    public class Role : IEntityBase<ObjectId>
    {
        public Role()
        {
            Users = new HashSet<UserRole>();
            Permissions = new HashSet<RolePermission>();
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
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<UserRole> Users { get; set; }
        public ICollection<RolePermission> Permissions { get; set; }
        public string CreatedBy { get; set; }
    }



    [NotMapped]
    public class IdRole
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
    [NotMapped]
    public class PermissionEntity
    {
        public Permission Permission { get; set; }
    }

    [NotMapped]
    public class UserAssignedPermissions
    {
        public string UserId { get; set; }
        public ObjectId RoleId { get; set; }
        public SecurableEnum SecuredItem { get; set; }
        public Permission Permission { get; set; }
        public string SecurableId { get; set; }
        public bool Assigned { get; set; }
    }
}
