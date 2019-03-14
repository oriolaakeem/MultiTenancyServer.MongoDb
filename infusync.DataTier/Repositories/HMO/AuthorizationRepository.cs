using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.HMO;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.HMO
{
    public class AuthorizationRepository : BaseRepository<AuthorizationCode, ObjectId>, ILogRepository<AuthorizationCode, ObjectId>
    {
        public AuthorizationRepository(IRepository<AuthorizationCode> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }
    }
}
