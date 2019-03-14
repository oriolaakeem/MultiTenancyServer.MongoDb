using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.HMO;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.HMO
{
    public class AttendanceRepository : BaseRepository<Attendance, ObjectId>, ILogRepository<Attendance, ObjectId>
    {
        public AttendanceRepository(IRepository<Attendance> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }
    }
}
