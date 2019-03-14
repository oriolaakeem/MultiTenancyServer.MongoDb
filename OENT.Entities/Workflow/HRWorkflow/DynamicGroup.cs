using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OENT.Entities.Workflow.HRWorkflow
{

    public class DynamicGroup : IEntityBase<ObjectId>

    {
        public DynamicGroup()
        {
            DynamicGroupMembers = new HashSet<DynamicGroupMember>();

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
        public ICollection<DynamicGroupMember> DynamicGroupMembers { get; set; }
        public string CreatedBy { get; set; }
     
    }



    public class DynamicGroupMember : IEntityBase<ObjectId>
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
        [Required]
        [MaxLength(50)]
        public string EmployeeId { get; set; }
        [MaxLength(200)]
        public string EmployeeName { get; set; }
        public string CreatedBy { get; set; }

    }


}
