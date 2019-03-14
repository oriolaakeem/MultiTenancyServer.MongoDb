using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.CompanyInfo;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.OndgoRepos
{
    public class CompanyRepository : BaseRepository<Company, ObjectId>, ILogRepository<Company, ObjectId>
    {
        public CompanyRepository(IRepository<Company> repository, IUserResolverService userResolverService)
            : base(repository, userResolverService)
        {

        }

    }
}
