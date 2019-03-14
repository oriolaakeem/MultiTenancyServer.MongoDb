using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.hr;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class HR_TaskAndTargetRepository : BaseRepository<HR_TaskAndTarget, ObjectId>, ILogRepository<HR_TaskAndTarget, ObjectId>
    {
        public HR_TaskAndTargetRepository(IRepository<HR_TaskAndTarget> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}