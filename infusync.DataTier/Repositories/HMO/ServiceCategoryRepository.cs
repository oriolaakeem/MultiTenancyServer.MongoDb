using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.HMO.Tarriffs;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.HMO
{
    public class ServiceCategoryRepository : BaseRepository<ServiceCategory, ObjectId>, ILogRepository<ServiceCategory, ObjectId>
    {
        public ServiceCategoryRepository(IRepository<ServiceCategory> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }
    }
}

