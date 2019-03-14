using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Employees;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee, ObjectId>, ILogRepository<Employee, ObjectId>
    {
        public EmployeeRepository(IRepository<Employee> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }
    }
}