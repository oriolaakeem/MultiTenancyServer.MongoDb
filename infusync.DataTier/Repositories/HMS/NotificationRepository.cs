using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Notifications;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class NotificationRepository : BaseRepository<Notification, ObjectId>, ILogRepository<Notification, ObjectId>
    {
        public NotificationRepository(IRepository<Notification> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
