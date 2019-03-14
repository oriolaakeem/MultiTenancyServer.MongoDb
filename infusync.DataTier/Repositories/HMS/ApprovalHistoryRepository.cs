using infusync.Security;
using MongoDB.Bson;
using OENT.Entities;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class ApprovalHistoryRepository : BaseRepository<ApprovalHistory, ObjectId>
    {
        public ApprovalHistoryRepository(IRepository<ApprovalHistory> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
