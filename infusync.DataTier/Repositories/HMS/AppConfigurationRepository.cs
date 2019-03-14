using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.General;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class AppConfigurationRepository : BaseRepository<AppConfiguration, ObjectId>, ILogRepository<AppConfiguration, ObjectId>
    {
        public AppConfigurationRepository(IRepository<AppConfiguration> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
