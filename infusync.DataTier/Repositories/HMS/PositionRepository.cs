using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.JobInfo;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class PositionRepository : BaseRepository<HR_Position, ObjectId>, ILogRepository<HR_Position, ObjectId>
    {
        public PositionRepository(IRepository<HR_Position> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
