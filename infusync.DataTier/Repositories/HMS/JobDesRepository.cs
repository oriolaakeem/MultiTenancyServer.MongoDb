using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.JobInfo;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class JobDesRepository : BaseRepository<JobDes, ObjectId>, ILogRepository<JobDes, ObjectId>
    {
        public JobDesRepository(IRepository<JobDes> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
