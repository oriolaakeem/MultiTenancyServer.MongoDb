using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.General;
using OryxDomainServices;

namespace infusync.DataTier.Repositories.GeneralServices
{
    public class UIComponentRepository : BaseRepository<UIComponent, ObjectId>, ILogRepository<UIComponent, ObjectId>
    {
        public UIComponentRepository(IRepository<UIComponent> dbFactory, IUserResolverService userResolverService)
            : base(dbFactory, userResolverService)
        {

        }
    }
}
