using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.General;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class FormControlOptionRepository : BaseRepository<FormControlOption, ObjectId>, ILogRepository<FormControlOption, ObjectId>
    {
        public FormControlOptionRepository(IRepository<FormControlOption> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
