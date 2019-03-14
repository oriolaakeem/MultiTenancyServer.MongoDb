using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OENT.Entities
{
    public class WorkFlow : IEntityBase<ObjectId>
    {
        public WorkFlow()
        {
            WorkFlowStates = new HashSet<WorkFlowState>();

        }
        [Key]
        public ObjectId Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string Code { get; set; }
        [Required, MaxLength(50)]
        public string MId { get; set; }

        [Required, MaxLength(1)]
        public string Status { get; set; }
        [Required]
        public DateTime EffectiveDate { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public DateTime? UpdateDate { get; set; }
        [Required, MaxLength(50)]
        public string UserSign { get; set; }

        public virtual ICollection<WorkFlowState> WorkFlowStates { get; set; }
        public string CreatedBy { get; set; }
    }

  
    [NotMapped]
    public class WorkFlowView : WorkFlow
    {
        public string ModuleName { get; set; }

    }
}
