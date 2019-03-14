using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Loans;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.OndgoRepos
{
    public class InvoiceRepository : BaseRepository<Invoice, ObjectId>, ILogRepository<Invoice, ObjectId>
    {
        public InvoiceRepository(IRepository<Invoice> dbFactory, IUserResolverService userResolverService)
            : base(dbFactory, userResolverService)
        {

        }
    }
}
