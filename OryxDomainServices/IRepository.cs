using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace OryxDomainServices
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> All();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter);

        TEntity Single(Expression<Func<TEntity, bool>> expression);
        TEntity Get(ObjectId id);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate);

        // add new note document
        Task Add(TEntity item);
        Task Add(TEntity item, string userId);

        // remove a single document / note
        Task Remove(ObjectId id);

        // update just a single document / note
        Task Update(ObjectId id, TEntity entity);

        Task Update(TEntity body);
        IEnumerable<TEntity> GetAll();
    }
}
