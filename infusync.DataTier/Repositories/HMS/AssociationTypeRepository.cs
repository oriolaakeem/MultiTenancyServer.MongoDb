using System;
using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.General;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class AssociationTypeRepository : BaseRepository<AssociationType, ObjectId>
    {
        public AssociationTypeRepository(IRepository<AssociationType> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
