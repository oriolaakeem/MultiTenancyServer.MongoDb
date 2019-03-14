using System;
using System.Collections.Generic;
using MongoDB.Bson;
using OENT.Entities.HMO.Plans;
using OryxDomainServices;

namespace OENT.Entities.HMO
{
    public class Plan : IEntityBase<ObjectId>
    {
        public Plan()
        {
            Benefits = new HashSet<PlanBenefit>();
        }

        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public double CapRate { get; set; }
        public double Premium { get; set; }
        public double MaxBenefit { get; set; }
        public int DependantCapacity { get; set; }
        public double CoveredAmount { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string CreatedBy { get; set; }
        public string Group { get; set; }

        public virtual ICollection<PlanBenefit> Benefits { get; set; }
    }
}

