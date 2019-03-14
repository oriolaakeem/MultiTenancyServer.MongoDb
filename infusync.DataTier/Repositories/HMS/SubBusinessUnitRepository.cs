using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.General;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class SubBusinessUnitRepository : BaseRepository<HR_SubBusinessUnit, ObjectId>, ILogRepository<HR_SubBusinessUnit, ObjectId>
    {
        public SubBusinessUnitRepository(IRepository<HR_SubBusinessUnit> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
