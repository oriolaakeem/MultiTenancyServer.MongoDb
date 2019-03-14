using MongoDB.Bson;

namespace OryxDomainServices
{
    public abstract class BaseServiceDecorator<TEntity, TId> : BaseService<TEntity, TId> where TEntity : IEntityBase<TId>
    {
        protected BaseService<TEntity, TId> _BaseService = null;
        protected BaseServiceDecorator(ILogRepository<TEntity, TId> repository, BaseService<TEntity, TId> baseService)
            : base(repository)
        {
            _BaseService = baseService;
        }
    }
}