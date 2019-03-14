using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class ApplicationRoleRepository : BaseRepository<ApplicationRole, ObjectId>, ILogRepository<ApplicationRole, ObjectId>
    {
        public ApplicationRoleRepository(IRepository<ApplicationRole> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
