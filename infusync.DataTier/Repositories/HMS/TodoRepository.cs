using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.General;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class TodoRepository : BaseRepository<Todo, ObjectId>, ILogRepository<Todo, ObjectId>
    {
        public TodoRepository(IRepository<Todo> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
