using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.hr;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class HR_AwardRepository : BaseRepository<HR_Award, ObjectId>, ILogRepository<HR_Award, ObjectId>
    {
        public HR_AwardRepository(IRepository<HR_Award> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }
    }
}