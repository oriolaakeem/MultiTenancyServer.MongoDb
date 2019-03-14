using infusync.Security;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace infusync.DataTier
{
    public class BaseRepository<TEntity, TId> : IBaseRepository<TEntity,TId>  where TEntity : class, IEntityBase<TId>, new()
    {
        protected IUserResolverService _userResolverService;
        protected IRepository<TEntity> _repository;

        public BaseRepository(IRepository<TEntity> repository, IUserResolverService userResolverService)
        {
            _repository = repository;
            _userResolverService = userResolverService;
        }


        public int Count => throw new NotImplementedException();

        public bool Contains(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public bool Contains(ObjectId id, DateTime effectiveDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Find(predicate);
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Get(predicate);
        }

        public virtual Task Add(TEntity item)
        {
            UpdateEntityForAdd(item);
            return _repository.Add(item);
        }

        public virtual Task Add(TEntity item, string userId)
        {
            UpdateEntityForAdd(item, userId);
            return _repository.Add(item);
        }

        public IEnumerable<TEntity> All()
        {
            return GetAll();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> filter)
        {
            return _repository.Find(filter);
        }

        public TEntity Get(ObjectId id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public Task Remove(ObjectId id)
        {
            return _repository.Remove(id);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> expression)
        {
            return _repository.Single(expression);
        }

        public Task Update(ObjectId id, TEntity body)
        {
            return _repository.Update(id, body);
        }

        public virtual Task Update(TEntity body)
        {
            return _repository.Update(ObjectId.Parse(body.Id.ToString()), body);
        }

        protected IEnumerable<T> ExecSQL<T>(string sql)
        {
            return null;
        }

        protected void UpdateEntityForAdd(IEntityBase<TId> entity, string userId = "")
        {
            if (!string.IsNullOrEmpty(userId))
            {
                entity.CreatedBy = userId;
            }
            else
            {
                var userName = _userResolverService.GetUser();
                entity.CreatedBy = userName.ToString();
            }
            entity.UpdateDate = DateTime.Now;
            entity.CreateDate = DateTime.Now;
            //entity.Status = "A";

        }

        protected void UpdateEntityForAdd(IEntityBase<TId> entity)
        {
            var userName = _userResolverService.GetUser();
            entity.CreatedBy = userName.ToString();
            entity.UpdateDate = DateTime.Now;
            entity.CreateDate = DateTime.Now;
            //entity.Status = "A";

        }

        protected void UpdateEntityForAdd(IEnumerable<IEntityBase<TId>> entities)
        {
            foreach (var entity in entities)
            {
                //entity.UserSign = userName;
                //entity.UpdateDate = System.DateTime.Now;
                //entity.CreateDate = System.DateTime.Now;
                var userName = _userResolverService.GetUser();
                entity.CreatedBy = userName.ToString();
                entity.UpdateDate = System.DateTime.Now;
                entity.CreateDate = System.DateTime.Now;
                //entity.Status = "A";
            }


        }

        protected void UpdateEntityForUpdate(IEntityBase<TId> entity)
        {
            entity.UpdateDate = System.DateTime.Now;

        }

        public void UpdateTracking(IEntityBase<TId> perm, EntityState state)
        {
            //dataContext.Entry(perm).State = state;

            if (state == EntityState.Added)
            {
                UpdateEntityForAdd(perm,"");
            }
            else
            {
                UpdateEntityForUpdate(perm,"");
            }
        }

        protected void UpdateEntityForUpdate(IEntityBase<TId> entity, string userId)
        {
            //string userName = _userResolverService.GetUser();
            entity.CreatedBy = userId;
            entity.UpdateDate = System.DateTime.Now;

        }

        protected void UpdateEntityForUpdate(IEnumerable<IEntityBase<TId>> entities)
        {
            foreach (var entity in entities)
            {
                var userName = _userResolverService.GetUser();
                entity.CreatedBy = userName.ToString();
                entity.UpdateDate = System.DateTime.Now;
            }
        }

    }

    public interface IBaseRepository<TEntity, TId> where TEntity : class, IEntityBase<TId>, new()
    {
    }

}

