using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.HMO.Tarriffs;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.HMO
{
    public class ServiceGroupRepository : BaseRepository<ServiceGroup, ObjectId>, ILogRepository<ServiceGroup, ObjectId>
    {
        public ServiceGroupRepository(IRepository<ServiceGroup> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }
    }
}

