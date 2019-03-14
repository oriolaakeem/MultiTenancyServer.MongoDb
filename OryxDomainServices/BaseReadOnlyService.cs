namespace OryxDomainServices
{
    using MongoDB.Bson;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    /// <summary>
    /// Abstract base class for a read only service.
    /// </summary>
    /// <typeparam name="TEntity">The entity type.</typeparam>
    /// <typeparam name="TId">The entity ID type.</typeparam>
    public abstract class BaseReadOnlyService<TEntity, ObjectId> where TEntity : IEntityBase<ObjectId>
    {
        private readonly IReadOnlyRepository<TEntity, ObjectId> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseReadOnlyService{TEntity, TId}"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <exception cref="System.ArgumentNullException">Thrown if repository is null.</exception>
        protected BaseReadOnlyService(IReadOnlyRepository<TEntity, ObjectId> repository)
        {
            _repository = repository ?? throw new ArgumentNullException("repository");
        }

        /// <summary>
        /// Count of entities.
        /// </summary>
        /// <returns>The total number of entities.</returns>
        public virtual int Count()
        {
            return _repository.Count;
        }

        /// <summary>
        /// Checks whether an entity with the specified unique identifier exists.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <returns><c>true</c> if entity exists, <c>false</c> otherwise.</returns>
        public virtual bool Exists(ObjectId id)
        {
            return _repository.Contains(id);
        }

        /// <summary>
        /// Gets the entity with the specified unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier.</param>
        /// <returns>The entity.</returns>
        /// <exception cref="System.Collections.Generic.KeyNotFoundException">Thrown if an entity with the given id is not found.</exception>
        public virtual TEntity Get(ObjectId id)
        {
            if (_repository.Contains(id))
            {
                return _repository.Get(id);
            }

            throw new KeyNotFoundException(string.Format("{0} with id {1} was not found", typeof(TEntity), id));
        }


        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>IEnumerable of entities.</returns>
        /// 
        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }


        /// <summary>
        /// Gets all entities.
        /// </summary>
        /// <returns>IEnumerable of entities.</returns>
        public virtual IEnumerable<TEntity> GetForLookup()
        {
            return null;
        }

        /// <summary>
        /// Filters the entities based on the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>IQueryable{TEntity}.</returns>
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Get(predicate);
        }
    }
}
