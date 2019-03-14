using infusync.Security;
using OryxDomainServices;
using OENT.Entities.Individual;
using MongoDB.Bson;

namespace infusync.DataTier.Repositories
{
    public class IndividualRepository : BaseRepository<Individual, ObjectId>, ILogRepository<Individual, ObjectId>
    {
        public IndividualRepository(IRepository<Individual> repository, IUserResolverService userResolverService)
            : base(repository, userResolverService)
        {

        }
    }
}
