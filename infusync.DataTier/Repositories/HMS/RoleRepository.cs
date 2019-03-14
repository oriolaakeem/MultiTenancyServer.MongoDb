using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class RoleRepository : BaseRepository<ApplicationRole, ObjectId>, ILogRepository<ApplicationRole, ObjectId>
    {
        public RoleRepository(IRepository<ApplicationRole> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }
    }
}
