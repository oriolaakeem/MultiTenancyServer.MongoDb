using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.JobInfo;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class TimeInfoRepository : BaseRepository<TimeInfo, ObjectId>, ILogRepository<TimeInfo, ObjectId>
    {
        public TimeInfoRepository(IRepository<TimeInfo> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
