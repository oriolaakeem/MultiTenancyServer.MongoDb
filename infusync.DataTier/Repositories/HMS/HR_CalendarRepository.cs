using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.hr;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class HR_CalendarRepository : BaseRepository<HR_Calendar, ObjectId>, ILogRepository<HR_Calendar, ObjectId>
    {
        public HR_CalendarRepository(IRepository<HR_Calendar> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }
    }
}