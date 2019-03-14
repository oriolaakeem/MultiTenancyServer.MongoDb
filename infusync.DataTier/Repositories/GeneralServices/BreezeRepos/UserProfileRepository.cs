using infusync.Security;
using OryxDomainServices;
using OENT.Entities;
using MongoDB.Bson;

namespace infusync.DataTier.Repositories.OndgoRepos
{
    public class UserProfileRepository : BaseRepository<ApplicationUser, ObjectId>
    {
        public UserProfileRepository(IRepository<ApplicationUser> dbFactory, IUserResolverService userResolverService)
            : base(dbFactory, userResolverService)
        {

        }
    }
}
