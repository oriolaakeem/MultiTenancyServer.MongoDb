using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.General;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class DepartmentRepository : BaseRepository<Department, ObjectId>, ILogRepository<Department, ObjectId>
    {
        public DepartmentRepository(IRepository<Department> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
