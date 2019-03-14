using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Loans;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.Repos
{
    public class TenureRepository : BaseRepository<Tenure, ObjectId>
    {
        public TenureRepository(IRepository<Tenure> dbFactory, IUserResolverService userResolverService)
            : base(dbFactory, userResolverService)
        {

        }
    }
}
