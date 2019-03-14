using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.JobInfo;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class JobRepository : BaseRepository<HR_Job, ObjectId>, ILogRepository<HR_Job, ObjectId>
    {
        public JobRepository(IRepository<HR_Job> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
