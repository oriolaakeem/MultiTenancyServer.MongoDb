using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class HRApprovalHistoryRepository : BaseRepository<HRApprovalHistory, ObjectId>, ILogRepository<HRApprovalHistory, ObjectId>
    {
        public HRApprovalHistoryRepository(IRepository<HRApprovalHistory> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
