using System;
using System.Linq;
using System.Linq.Expressions;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.Patients;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class AppointmentRepository : BaseRepository<Appointment, ObjectId>, ILogRepository<Appointment, ObjectId>
    {
        public AppointmentRepository(IRepository<Appointment> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }

       
    }
}
