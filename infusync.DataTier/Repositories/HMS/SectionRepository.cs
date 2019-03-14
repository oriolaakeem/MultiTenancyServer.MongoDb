using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.General;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class SectionRepository : BaseRepository<Section, ObjectId>, ILogRepository<Section, ObjectId>
    {
        public SectionRepository(IRepository<Section> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
