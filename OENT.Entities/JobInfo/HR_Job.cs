using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using OENT.Entities.General;
using OryxDomainServices;

namespace OENT.Entities.JobInfo
{
   //[OSSOAssociation("Job")]
    public class HR_Job : IEntityBase<ObjectId>
    {

        public HR_Job()
        {
            JobDepartments = new HashSet<JobDepartment>();
            Associations = new HashSet<AssociationEntity>();

        }
        [NotMapped]
        public IEnumerable<AssociationEntity> Associations { get; set; }
        public ObjectId Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [MaxLength(100)]
        public string PayGrade { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(1)]
        public string Status { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserSign { get; set; }
        public ICollection<JobDepartment> JobDepartments { get; set; }
        public string CreatedBy { get; set; }
    }
}
