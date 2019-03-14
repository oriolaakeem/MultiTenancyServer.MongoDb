using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.General;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class DefinitionRepository : BaseRepository<Definition, ObjectId>, ILogRepository<Definition, ObjectId>
    {
        public DefinitionRepository(IRepository<Definition> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
