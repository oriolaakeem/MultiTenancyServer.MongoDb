using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.General;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class BusinessUnitRepository : BaseRepository<HR_BusinessUnit, ObjectId>, ILogRepository<HR_BusinessUnit, ObjectId>
    {
        public BusinessUnitRepository(IRepository<HR_BusinessUnit> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
