using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.HMO;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.HMO
{
    public class SubscriptionRepository : BaseRepository<Subscription, ObjectId>, ILogRepository<Subscription, ObjectId>
    {
        public SubscriptionRepository(IRepository<Subscription> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }
    }
}
