using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Authorization;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class SecurableRepository : BaseRepository<Securable, ObjectId>, ILogRepository<Securable, ObjectId>
    {
        public SecurableRepository(IRepository<Securable> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
