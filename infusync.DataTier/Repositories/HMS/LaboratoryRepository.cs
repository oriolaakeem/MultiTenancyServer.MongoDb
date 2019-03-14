using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Patients;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class LaboratoryRepository : BaseRepository<Laboratory, ObjectId>, ILogRepository<Laboratory, ObjectId>
    {
        public LaboratoryRepository(IRepository<Laboratory> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
