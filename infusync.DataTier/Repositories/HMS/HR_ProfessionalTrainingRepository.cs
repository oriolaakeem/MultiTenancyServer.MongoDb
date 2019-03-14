using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.hr;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class HR_ProfessionalTrainingRepository : BaseRepository<HR_ProfessionalTraining, ObjectId>, ILogRepository<HR_ProfessionalTraining, ObjectId>
    {
        public HR_ProfessionalTrainingRepository(IRepository<HR_ProfessionalTraining> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
