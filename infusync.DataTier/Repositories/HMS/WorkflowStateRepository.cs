using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class WorkflowStateRepository : BaseRepository<WorkFlowState, ObjectId>, ILogRepository<WorkFlowState, ObjectId>
    {
        public WorkflowStateRepository(IRepository<WorkFlowState> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
