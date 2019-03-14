using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Patients;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class VitalsRepository : BaseRepository<Vitals, ObjectId>, ILogRepository<Vitals, ObjectId>
    {
        public VitalsRepository(IRepository<Vitals> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
