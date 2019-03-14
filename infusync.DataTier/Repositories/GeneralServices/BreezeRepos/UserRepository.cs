using infusync.Security;
using MongoDB.Bson;
using OENT.Entities;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.OndgoRepos
{
    public class UserRepository : BaseRepository<ApplicationUser, ObjectId>, ILogRepository<ApplicationUser, ObjectId>
    {
        public UserRepository(IRepository<ApplicationUser> dbFactory, IUserResolverService userResolverService)
            : base(dbFactory, userResolverService)
        {

        }
    }
}
