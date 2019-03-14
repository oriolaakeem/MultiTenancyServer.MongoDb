using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;
using OryxDomainServices;

namespace OENT.Entities
{
    public class ApplicationRole : MongoIdentityRole<ObjectId>, IEntityBase<ObjectId>
    {
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime EffectiveDate { get; set; }
        public string Status { get; set; }
        public string UserSign { get; set; }
        public string CreatedBy { get; set; }

        public ApplicationRole() : base()
        {
            Users = new HashSet<UserRole>();
            Permissions = new HashSet<RolePermission>();
        }

        public ApplicationRole(string roleName) : base(roleName)
        {
            Users = new HashSet<UserRole>();
            Permissions = new HashSet<RolePermission>();
        }

        public ICollection<UserRole> Users { get; set; }
        public ICollection<RolePermission> Permissions { get; set; }
        ObjectId IEntityBase<ObjectId>.Id { get; set; } = ObjectId.GenerateNewId();
    }

    public enum Permission
    {
        Add = 0,
        Update = 1,
        Remove = 2,
        View = 3,
        Assign = 4,
        Workflow = 5,
    }

    //public class UserRole : IEntityBase<ObjectId>
    //{
    //    public ObjectId Id { get; set; }
    //    public DateTime CreateDate { get; set; }
    //    public string CreatedBy { get; set; }
    //    public DateTime? UpdateDate { get; set; }
    //    public DateTime EffectiveDate { get; set; }
    //    [MaxLength(1)]
    //    public string Status { get; set; }
    //    [Required]
    //    [MaxLength(50)]
    //    public string UserSign { get; set; }
    //    [Required]
    //    [MaxLength(50)]
    //    public string UserId { get; set; }
    //    [Required]
    //    [MaxLength(50)]
    //    public ObjectId RoleId { get; set; }

    //}

    //public class RolePermission : IEntityBase<ObjectId>
    //{
    //    public ObjectId Id { get; set; }
    //    public DateTime CreateDate { get; set; }
    //    public string CreatedBy { get; set; }
    //    public DateTime? UpdateDate { get; set; }
    //    public DateTime EffectiveDate { get; set; }
    //    [MaxLength(1)]
    //    public string Status { get; set; }
    //    [Required]
    //    [MaxLength(50)]
    //    public string UserSign { get; set; }
    //    [Required]
    //    [MaxLength(50)]
    //    public ObjectId RoleId { get; set; }
    //    [Required]
    //    public Permission Permission { get; set; }
    //    [Required]
    //    public string SecurableId { get; set; }
    //    [Required]
    //    public bool Assigned { get; set; }

    //}

}