using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Loans;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.OndgoRepos
{
    public class InvoiceLineItemRepository : BaseRepository<InvoiceLineItem, ObjectId>
    {
        public InvoiceLineItemRepository(IRepository<InvoiceLineItem> repository, IUserResolverService userResolverService)
            : base(repository, userResolverService)
        {

        }
    }
}
