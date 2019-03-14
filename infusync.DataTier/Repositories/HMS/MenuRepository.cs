using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.General;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class MenuRepository : BaseRepository<Menu, ObjectId>, ILogRepository<Menu, ObjectId>
    {
        public MenuRepository(IRepository<Menu> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
