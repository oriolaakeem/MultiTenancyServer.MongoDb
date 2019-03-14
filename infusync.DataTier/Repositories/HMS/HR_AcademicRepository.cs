using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.hr;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class HR_AcademicRepository : BaseRepository<HR_Academic, ObjectId>, ILogRepository<HR_Academic, ObjectId>
    {
        public HR_AcademicRepository(IRepository<HR_Academic> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
