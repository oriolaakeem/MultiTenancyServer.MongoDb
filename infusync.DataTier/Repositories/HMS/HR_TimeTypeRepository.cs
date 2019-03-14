using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.hr;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class HR_TimeTypeRepository : BaseRepository<HR_TimeType, ObjectId>, ILogRepository<HR_TimeType, ObjectId>
    {
        public HR_TimeTypeRepository(IRepository<HR_TimeType> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
