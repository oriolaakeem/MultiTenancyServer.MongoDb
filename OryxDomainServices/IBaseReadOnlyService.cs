namespace OryxDomainServices
{
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IBaseReadOnlyService<TEntity, ObjectId> where TEntity : IEntityBase<ObjectId>
    {
        IMongoCollection<TEntity> All();
        int Count();
        bool Exists(ObjectId id);
        TEntity Get(ObjectId id);
        IQueryable<TEntity> GetAll();
        IEnumerable<TEntity> GetForLookup();
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
    }
}
