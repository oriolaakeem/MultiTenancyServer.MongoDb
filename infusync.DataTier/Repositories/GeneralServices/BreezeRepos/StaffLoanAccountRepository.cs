using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.StaffManagement;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.OndgoRepos
{
    public class StaffLoanAccountRepository : BaseRepository<StaffLoanAccount, ObjectId>
    {
        public StaffLoanAccountRepository(IRepository<StaffLoanAccount> dbFactory, IUserResolverService userResolverService)
            : base(dbFactory, userResolverService)
        {

        }
    }
}
