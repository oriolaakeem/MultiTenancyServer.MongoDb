using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.HMO.Plans;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.HMO
{
    public class PlanBenefitsRepository : BaseRepository<PlanBenefit, ObjectId>, ILogRepository<PlanBenefit, ObjectId>
    {
        public PlanBenefitsRepository(IRepository<PlanBenefit> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }
    }
}
