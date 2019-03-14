using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.General;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class JunctionObjectRepository : BaseRepository<JunctionObject, ObjectId>, ILogRepository<JunctionObject, ObjectId>
    {
        public JunctionObjectRepository(IRepository<JunctionObject> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
