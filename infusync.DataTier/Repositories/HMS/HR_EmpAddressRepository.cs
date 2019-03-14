using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.hr;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class HR_EmpAddressRepository : BaseRepository<HR_EmpAddress, ObjectId>, ILogRepository<HR_EmpAddress, ObjectId>
    {
        public HR_EmpAddressRepository(IRepository<HR_EmpAddress> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }
    }
}