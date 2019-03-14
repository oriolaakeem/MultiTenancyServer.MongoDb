using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.JobInfo;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class JobInfoRepository : BaseRepository<JobInfo, ObjectId>, ILogRepository<JobInfo, ObjectId>
    {
        public JobInfoRepository(IRepository<JobInfo> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {

        }
    }
}
