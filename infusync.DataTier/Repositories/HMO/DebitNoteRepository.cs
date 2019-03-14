using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.HMO;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.HMO
{
    public class DebitNoteRepository : BaseRepository<DebitNote, ObjectId>, ILogRepository<DebitNote, ObjectId>
    {
        public DebitNoteRepository(IRepository<DebitNote> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }
    }
}
