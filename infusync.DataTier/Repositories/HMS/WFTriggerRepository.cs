using infusync.Security;
using MongoDB.Bson;
using OENT.Entities;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class WFTriggerRepository : BaseRepository<WFTrigger, ObjectId>, ILogRepository<WFTrigger, ObjectId>
    {
        public WFTriggerRepository(IRepository<WFTrigger> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
