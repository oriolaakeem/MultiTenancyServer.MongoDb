using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Authorization;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.OndgoRepos
{
    public class PermissionRepository : BaseRepository<Permission, ObjectId>, ILogRepository<Permission, ObjectId>
    {
        public PermissionRepository(IRepository<Permission> dbFactory, IUserResolverService userResolverService)
            : base(dbFactory, userResolverService)
        {

        }
    }
}
