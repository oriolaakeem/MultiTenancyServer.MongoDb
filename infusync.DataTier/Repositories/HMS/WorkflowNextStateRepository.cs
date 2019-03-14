using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class WorkflowNextStateRepository : BaseRepository<WorkflowNextState, ObjectId>, ILogRepository<WorkflowNextState, ObjectId>
    {
        public WorkflowNextStateRepository(IRepository<WorkflowNextState> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
