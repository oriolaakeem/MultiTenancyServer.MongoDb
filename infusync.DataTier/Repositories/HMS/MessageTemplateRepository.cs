using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Notifications;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class MessageTemplateRepository : BaseRepository<MessageTemplate, ObjectId>, ILogRepository<MessageTemplate, ObjectId>
    {
        public MessageTemplateRepository(IRepository<MessageTemplate> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
