using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.hr;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class HR_CreationRuleRepository : BaseRepository<HR_CreationRule, ObjectId>, ILogRepository<HR_CreationRule, ObjectId>
    {
        public HR_CreationRuleRepository(IRepository<HR_CreationRule> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }
    }
}