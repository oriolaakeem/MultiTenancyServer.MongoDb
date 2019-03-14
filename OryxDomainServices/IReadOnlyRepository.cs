using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OryxDomainServices
{
    public interface IReadOnlyRepository<IEntityBase, in TId> where IEntityBase : IEntityBase<TId>
    {
        /// <summary>
        /// Gets the number of entities in the repository.
        /// </summary>
        /// <returns>The total number of entities.</returns>
        int Count { get; }

        /// <summary>
        /// Determines whether the repository contains an entity with the specified id.
        /// </summary>
        /// <param name="id">The entity id.</param>
        /// <returns><c>true</c> if the repository contains an entity with the specified id; otherwise, <c>false</c>.</returns>
        bool Contains(TId id);
        bool Contains(TId id, DateTime effectiveDate);

        /// <summary>
        /// Gets the entity with the specified id.
        /// </summary>
        /// <param name="id">The entity id.</param>
        /// <returns>The entity.</returns>
        IEntityBase Get(TId id);

        /// <summary>
        /// Filters the entities based on the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>IQueryable{TEntity}.</returns>
        IEnumerable<IEntityBase> Get(Expression<Func<IEntityBase, bool>> predicate);

        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>A list of entities.</returns>
        IEnumerable<IEntityBase> GetAll();

        IEnumerable<IEntityBase> FindBy(Expression<Func<IEntityBase, bool>> predicate);

        //IQueryable<IEntityBase> AllIncluding(params Expression<Func<IEntityBase, object>>[] includeProperties);
    }
}

