using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.HMO.Plans;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.HMO
{
    public class PlanGroupsRepository : BaseRepository<PlanGroup, ObjectId>, ILogRepository<PlanGroup, ObjectId>
    {
        public PlanGroupsRepository(IRepository<PlanGroup> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }
    }
}
