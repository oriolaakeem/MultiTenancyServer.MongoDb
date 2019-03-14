using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Loans;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.OndgoRepos
{
    public class LoanRepository : BaseRepository<Loan, ObjectId>, ILogRepository<Loan, ObjectId>
    {
        public LoanRepository(IRepository<Loan> dbFactory, IUserResolverService userResolverService)
            : base(dbFactory, userResolverService)
        {

        }
    }
}
