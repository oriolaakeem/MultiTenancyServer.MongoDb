using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Patients;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class PatientRepository : BaseRepository<Patient, ObjectId>, ILogRepository<Patient, ObjectId>
    {
        public PatientRepository(IRepository<Patient> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
