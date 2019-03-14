using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.General;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.GeneralServices
{
    public class LabelRepository : BaseRepository<Label, ObjectId>, ILogRepository<Label, ObjectId>
    {
        public LabelRepository(IRepository<Label> dbFactory, IUserResolverService userResolverService)
            : base(dbFactory, userResolverService)
        {

        }
    }
}