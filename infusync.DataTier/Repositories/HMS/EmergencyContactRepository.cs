using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Employees;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class EmergencyContactRepository : BaseRepository<EmergencyContact, ObjectId>, ILogRepository<EmergencyContact, ObjectId>
    {
        public EmergencyContactRepository(IRepository<EmergencyContact> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
