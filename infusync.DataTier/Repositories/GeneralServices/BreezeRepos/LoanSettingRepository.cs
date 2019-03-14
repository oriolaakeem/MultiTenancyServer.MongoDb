using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Loans;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.OndgoRepos
{
    public class LoanSettingRepository : BaseRepository<LoanSetting, ObjectId>
    {
        public LoanSettingRepository(IRepository<LoanSetting> dbFactory, IUserResolverService userResolverService)
            : base(dbFactory, userResolverService)
        {

        }
    }
}
