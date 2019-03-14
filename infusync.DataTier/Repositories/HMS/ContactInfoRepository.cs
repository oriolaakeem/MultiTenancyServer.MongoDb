using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Employees;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class ContactInfoRepository : BaseRepository<ContactInfo, ObjectId>, ILogRepository<ContactInfo, ObjectId>
    {
        public ContactInfoRepository(IRepository<ContactInfo> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
