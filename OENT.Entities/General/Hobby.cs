using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OENT.Entities.General
{
    public class HR_Division : IEntityBase<ObjectId>
    {
        public HR_Division()
        {
            Associations = new HashSet<AssociationEntity>();
        }
        [NotMapped]
        public IEnumerable<AssociationEntity> Associations { get; set; }

        
        public ObjectId Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string Code { get; set; }
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
        public string HeadOfDivision { get; set; }
        [MaxLength(100)]
        public string HeadOfDivisionName { get; set; }
        public string CreatedBy { get; set; }

    }

    public class HR_BusinessUnit : IEntityBase<ObjectId>
    {
        public HR_BusinessUnit()
        {
            Associations = new HashSet<AssociationEntity>();
        }
        [NotMapped]
        public IEnumerable<AssociationEntity> Associations { get; set; }
        public ObjectId Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string Code { get; set; }
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
        public string HeadOfBusinessUnit { get; set; }
        [MaxLength(100)]
        public string HeadOfBusinessUnitName { get; set; }
        public string CreatedBy { get; set; }
    }
    public class Hobby : IEntityBase<ObjectId>
    {
        [Key]
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
        [MaxLength(50)]
        [Required]
        public string EmployeeId { get; set; }
        public string CreatedBy { get; set; }
    }
}
