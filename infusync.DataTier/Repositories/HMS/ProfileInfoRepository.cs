using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Employees;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class ProfileInfoRepository : BaseRepository<ProfileInfo, ObjectId>, ILogRepository<ProfileInfo, ObjectId>
    {
        public ProfileInfoRepository(IRepository<ProfileInfo> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
