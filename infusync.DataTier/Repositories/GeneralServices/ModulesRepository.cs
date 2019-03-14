using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.General;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.GeneralServices
{
    public class ModulesRepository : BaseRepository<Module, ObjectId>, ILogRepository<Module, ObjectId>
    {
        public ModulesRepository(IRepository<Module> repository, IUserResolverService UserResolverService)
         : base(repository, UserResolverService)
        {
        }
    }
}
