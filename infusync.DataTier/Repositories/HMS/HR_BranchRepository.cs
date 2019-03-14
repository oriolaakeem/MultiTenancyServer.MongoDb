using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.hr;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class HR_BranchRepository : BaseRepository<HR_Branch, ObjectId>, ILogRepository<HR_Branch, ObjectId>
    {
        public HR_BranchRepository(IRepository<HR_Branch> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }
    }
}