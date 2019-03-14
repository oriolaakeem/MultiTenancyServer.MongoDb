using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.hr;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class HR_KPIRepository : BaseRepository<HR_KPI, ObjectId>, ILogRepository<HR_KPI, ObjectId>
    {
        public HR_KPIRepository(IRepository<HR_KPI> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
