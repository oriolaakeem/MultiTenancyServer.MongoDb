using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Employees;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class DependantInfoRepository : BaseRepository<DependantInfo, ObjectId>, ILogRepository<DependantInfo, ObjectId>
    {
        public DependantInfoRepository(IRepository<DependantInfo> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
