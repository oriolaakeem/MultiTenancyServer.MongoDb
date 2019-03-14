using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.General;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class DivisionRepository : BaseRepository<HR_Division, ObjectId>, ILogRepository<HR_Division, ObjectId>
    {
        public DivisionRepository(IRepository<HR_Division> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
