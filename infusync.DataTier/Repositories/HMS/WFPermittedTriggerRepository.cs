using System;
using System.Collections.Generic;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class WFPermittedTriggerRepository : BaseRepository<WFPermittedTrigger, ObjectId>, ILogRepository<WFPermittedTrigger, ObjectId>
    {
        public WFPermittedTriggerRepository(IRepository<WFPermittedTrigger> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }

        public IEnumerable<WFPermittedTriggerView> GetWFPermittedTriggerView(ObjectId StateId)
        {
            string sql = "SELECT a.*, b.Name TriggerName, c.Name NextStateName FROM dbo.WFPermittedTriggers a "
                + " left outer join WFTriggers b on a.WFTriggerId = b.Id "
                + " left outer join WFStates c on a.NextState = c.Id"
                + " Where a.WFStateId = '" + StateId.ToString() + "'";


            return ExecSQL<WFPermittedTriggerView>(sql);
        }

        public IEnumerable<WFPermittedTriggerView> GetWFPermittedTriggerView()
        {
            string sql = "SELECT a.*, b.Name TriggerName, c.Name NextStateName FROM dbo.WFPermittedTriggers a "
                + " left outer join WFTriggers b on a.WFTriggerId = b.Id "
                + " left outer join WFStates c on a.NextState = c.Id";


            return ExecSQL<WFPermittedTriggerView>(sql);
        }

    }
}
