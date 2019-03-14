using infusync.Security;
using MongoDB.Bson;
using OENT.Entities;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class HRApprovalPathRepository : BaseRepository<HRApprovalPath, ObjectId>, ILogRepository<HRApprovalPath, ObjectId>
    {
        public HRApprovalPathRepository(IRepository<HRApprovalPath> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
