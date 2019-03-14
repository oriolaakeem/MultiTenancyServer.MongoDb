using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.HMO;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.HMO
{
    public class PlanRepository : BaseRepository<Plan, ObjectId>, ILogRepository<Plan, ObjectId>
    {
        public PlanRepository(IRepository<Plan> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }
    }
}
