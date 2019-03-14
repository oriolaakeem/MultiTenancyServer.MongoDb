using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Employees;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class BiographicalInfoRepository : BaseRepository<BiographicalInfo, ObjectId>, ILogRepository<BiographicalInfo, ObjectId>
    {
        public BiographicalInfoRepository(IRepository<BiographicalInfo> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
