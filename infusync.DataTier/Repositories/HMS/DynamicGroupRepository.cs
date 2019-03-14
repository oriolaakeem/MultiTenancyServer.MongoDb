using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Workflow.HRWorkflow;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class DynamicGroupRepository : BaseRepository<DynamicGroup, ObjectId>, ILogRepository<DynamicGroup, ObjectId>
    {
        public DynamicGroupRepository(IRepository<DynamicGroup> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
