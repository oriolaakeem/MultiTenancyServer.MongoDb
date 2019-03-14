using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Loans;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.OndgoRepos
{
    public class LoanRepaymentRepository : BaseRepository<LoanRepayment, ObjectId>
    {
        public LoanRepaymentRepository(IRepository<LoanRepayment> dbFactory, IUserResolverService userResolverService)
            : base(dbFactory, userResolverService)
        {

        }
    }
}
