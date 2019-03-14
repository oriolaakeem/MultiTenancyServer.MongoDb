using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.StaffManagement;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.OndgoRepos
{
    public class StaffAccountRepository : BaseRepository<StaffAccount, ObjectId>, ILogRepository<StaffAccount, ObjectId>
    {
        public StaffAccountRepository(IRepository<StaffAccount> dbFactory, IUserResolverService userResolverService)
            : base(dbFactory, userResolverService)
        {

        }
    }
}
