using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.HMO;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.HMO
{
    public class CapitationRepository : BaseRepository<Capitation, ObjectId>, ILogRepository<Capitation, ObjectId>
    {
        public CapitationRepository(IRepository<Capitation> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }
    }
}
