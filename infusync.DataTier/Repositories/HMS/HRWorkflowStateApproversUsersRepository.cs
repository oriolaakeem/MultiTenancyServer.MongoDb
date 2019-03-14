using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class HRWorkflowStateApproversUsersRepository : BaseRepository<HRWorkflowStateApproversUsers, ObjectId>, ILogRepository<HRWorkflowStateApproversUsers, ObjectId>
    {
        public HRWorkflowStateApproversUsersRepository(IRepository<HRWorkflowStateApproversUsers> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
