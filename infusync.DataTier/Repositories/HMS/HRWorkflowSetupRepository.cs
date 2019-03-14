using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Workflow;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class HRWorkflowSetupRepository : BaseRepository<HRWorkflowSetup, ObjectId>, ILogRepository<HRWorkflowSetup, ObjectId>
    {
        public HRWorkflowSetupRepository(IRepository<HRWorkflowSetup> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
