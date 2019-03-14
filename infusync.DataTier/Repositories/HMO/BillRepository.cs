using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.HMO.Billings;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.HMO
{
    public class BillRepository : BaseRepository<Bill, ObjectId>, ILogRepository<Bill, ObjectId>
    {
        public BillRepository(IRepository<Bill> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }
    }
}
