using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.HMO.Tarriffs;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.HMO
{
    public class TarrifRepository : BaseRepository<ServiceTariff, ObjectId>, ILogRepository<ServiceTariff, ObjectId>
    {
        public TarrifRepository(IRepository<ServiceTariff> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }
    }
}
