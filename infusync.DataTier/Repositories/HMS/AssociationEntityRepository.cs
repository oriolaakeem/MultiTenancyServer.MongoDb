using infusync.Security;
using MongoDB.Bson;
using OENT.Entities.General;
using OryxDomainServices;

namespace infusync.DataTier.Repositories
{
    public class AssociationEntityRepository : BaseRepository<AssociationEntity, ObjectId>
    {
        public AssociationEntityRepository(IRepository<AssociationEntity> repository, IUserResolverService UserResolverService) : base(repository, UserResolverService)
        {
        }
    }
}
