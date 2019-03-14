using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.General;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class PersonalizationRepository : BaseRepository<Personalization, ObjectId>, ILogRepository<Personalization, ObjectId>
    {
        public PersonalizationRepository(IRepository<Personalization> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
