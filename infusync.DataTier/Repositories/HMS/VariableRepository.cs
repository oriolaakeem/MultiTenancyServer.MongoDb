using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Notifications;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class VariableRepository : BaseRepository<Variable, ObjectId>, ILogRepository<Variable, ObjectId>
    {
        public VariableRepository(IRepository<Variable> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
