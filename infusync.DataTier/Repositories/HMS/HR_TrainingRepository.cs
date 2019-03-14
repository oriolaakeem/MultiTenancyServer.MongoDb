using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.hr;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class HR_TrainingRepository : BaseRepository<HR_Training, ObjectId>, ILogRepository<HR_Training, ObjectId>
    {
        public HR_TrainingRepository(IRepository<HR_Training> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
