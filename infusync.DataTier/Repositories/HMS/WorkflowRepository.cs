using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class WorkflowRepository : BaseRepository<WorkFlow, ObjectId>, ILogRepository<WorkFlow, ObjectId>
    {
        public WorkflowRepository(IRepository<WorkFlow> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
