using infusync.Security;
using MongoDB.Bson;
using OENT.Entities;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class TriggerRepository : BaseRepository<WFTrigger, ObjectId>, ILogRepository<WFTrigger, ObjectId>
    {
        public TriggerRepository(IRepository<WFTrigger> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
