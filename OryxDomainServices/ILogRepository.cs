using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OryxDomainServices
{
    public interface ILogRepository<IEntityBase, in TId> : IReadOnlyRepository<IEntityBase, TId> where IEntityBase : IEntityBase<TId> 
    {
        IEnumerable<IEntityBase> All();

        IEnumerable<IEntityBase> Find(Expression<Func<IEntityBase, bool>> filter);

        IEntityBase Single(Expression<Func<IEntityBase, bool>> expression);

        // add new note document
        Task Add(IEntityBase item);
        Task Add(IEntityBase item, string userId);

        // remove a single document / note
        Task Remove(TId id);

        // update just a single document / note
        Task Update(TId id, IEntityBase entity);

        Task Update(IEntityBase body);
    }

    public interface ILogRepository<IEntityBase, ILogEntityBase, in TId> : ILogRepository<IEntityBase, TId> where IEntityBase : IEntityBase<TId>
           where ILogEntityBase : ILogEntityBase<TId>
    {

    }
}