using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.HMO.Hospitals;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.HMO
{
    public class HospitalRepository : BaseRepository<Hospital, ObjectId>, ILogRepository<Hospital, ObjectId>
    {
        public HospitalRepository(IRepository<Hospital> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }


    }

}
