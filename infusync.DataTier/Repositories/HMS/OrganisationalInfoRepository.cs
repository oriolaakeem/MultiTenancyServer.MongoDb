using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.JobInfo;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class OrganisationalInfoRepository : BaseRepository<OrganisationalInfo, ObjectId>, ILogRepository<OrganisationalInfo, ObjectId>
    {
        public OrganisationalInfoRepository(IRepository<OrganisationalInfo> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
