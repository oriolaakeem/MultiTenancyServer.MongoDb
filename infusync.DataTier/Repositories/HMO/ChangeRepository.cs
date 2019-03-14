using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.HMO;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.HMO
{
    public class ChangeRepository : BaseRepository<Change, ObjectId>, ILogRepository<Change, ObjectId>
    {
        public ChangeRepository(IRepository<Change> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }
    }
}
