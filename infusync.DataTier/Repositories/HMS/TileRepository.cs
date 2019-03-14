using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.General;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class TileRepository : BaseRepository<Tile, ObjectId>, ILogRepository<Tile, ObjectId>
    {
        public TileRepository(IRepository<Tile> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
