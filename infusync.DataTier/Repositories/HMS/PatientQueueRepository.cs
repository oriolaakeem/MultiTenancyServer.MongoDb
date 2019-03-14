using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.General;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class PatientQueueRepository : BaseRepository<PatientQueue, ObjectId>, ILogRepository<PatientQueue, ObjectId>
    {
        public PatientQueueRepository(IRepository<PatientQueue> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
