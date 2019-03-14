using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.HMO;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.HMO
{
    public class CreditNoteRepository : BaseRepository<CreditNote, ObjectId>, ILogRepository<CreditNote, ObjectId>
    {
        public CreditNoteRepository(IRepository<CreditNote> repository, IUserResolverService userResolverService) : base(repository, userResolverService)
        {
        }
    }
}
