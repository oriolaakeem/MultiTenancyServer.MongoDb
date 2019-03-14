using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Workflow;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class HRWorkflowInstanceRepository : BaseRepository<HRWorkflowInstance, ObjectId>, ILogRepository<HRWorkflowInstance, ObjectId>
    {
        public HRWorkflowInstanceRepository(IRepository<HRWorkflowInstance> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }

}
