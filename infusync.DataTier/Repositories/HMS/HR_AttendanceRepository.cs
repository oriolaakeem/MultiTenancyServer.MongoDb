using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.hr;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class HR_AttendanceRepository : BaseRepository<HR_Attendance, ObjectId>, ILogRepository<HR_Attendance, ObjectId>
    {
        public HR_AttendanceRepository(IRepository<HR_Attendance> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }
    }
}
