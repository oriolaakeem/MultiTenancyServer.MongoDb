using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class HRWorkflowGroupEmployeeRepository : BaseRepository<HRWorkflowGroupEmployee, ObjectId>, ILogRepository<HRWorkflowGroupEmployee, ObjectId>
    {
        public HRWorkflowGroupEmployeeRepository(IRepository<HRWorkflowGroupEmployee> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
