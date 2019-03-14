using infusync.Security;
using MongoDB.Bson;
using OENT.Entities;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class WFStateRepository : BaseRepository<WFState, ObjectId>, ILogRepository<WFState, ObjectId>
    {
        public WFStateRepository(IRepository<WFState> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
