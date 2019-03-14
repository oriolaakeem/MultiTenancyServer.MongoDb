using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.HMO.Enrollees;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.HMO
{
    public class EnrolleeRepository : BaseRepository<Enrollee, ObjectId>, ILogRepository<Enrollee, ObjectId>
    {
        public EnrolleeRepository(IRepository<Enrollee> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }
    }

}
