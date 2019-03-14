using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Employees;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class PersonInfoRepository:BaseRepository<PersonInfo, ObjectId>, ILogRepository<PersonInfo, ObjectId>
    {

        public PersonInfoRepository(IRepository<PersonInfo> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
