//using Breeze.DataTier.Infrastructure;
//using Breeze.Security;
//using Microsoft.EntityFrameworkCore;
//using OryxDomainServices;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Reflection;
//using System.Text;

//namespace Breeze.DataTier.Repositories
//{
//    public class BaseBreezeRepository<TEntity, TId> : IBaseBreezeRepository<TEntity, TId>
//        where TEntity : class, IEntityBase<TId>, new()
//    {
//        protected BreezeDataContext dataContext;
//        protected readonly DbSet<TEntity> dbSet;
//        protected IUserResolverService _userResolverService;

//        protected IDbFactory DbFactory
//        {
//            get;
//            private set;
//        }

//        protected BreezeDataContext DbContext
//        {
//            get { return dataContext ?? (dataContext = DbFactory.Init()); }
//        }

//        public BaseBreezeRepository(IDbFactory dbFactory, IUserResolverService UserResolverService)
//        {
//            DbFactory = dbFactory;
//            dbSet = DbContext.Set<TEntity>();
//            _userResolverService = UserResolverService;
//        }

//        public int Count => throw new NotImplementedException();

//        public void Add(TEntity entity)
//        {
//            this.UpdateEntityForAdd(entity);
//            dataContext.Add(entity);
//        }

//        public void Add(TEntity entity, string userId)
//        {
//            this.UpdateEntityForAdd(entity, userId);
//            dataContext.Add(entity);
//        }

//        public IQueryable<TEntity> All()
//        {
//            return GetAll();
//        }

//        public IQueryable<TEntity> AllIncluding(params Expression<Func<TEntity, object>>[] includeProperties)
//        {
//            IQueryable<TEntity> query = DbContext.Set<TEntity>();
//            foreach (var includeProperty in includeProperties)
//            {
//                query = query.Include(includeProperty);
//            }
//            return query;
//        }

//        public IQueryable<TEntity> AllIncludingNoTracking(params Expression<Func<TEntity, object>>[] includeProperties)
//        {
//            IQueryable<TEntity> query = DbContext.Set<TEntity>().AsNoTracking();
//            foreach (var includeProperty in includeProperties)
//            {
//                query = query.Include(includeProperty);
//            }
//            return query;
//        }

//        public bool Contains(TId id)
//        {
//            return GetAll().Any(x => x.Id.Equals(id));
//        }

//        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
//        {
//            return DbContext.Set<TEntity>().Where(predicate);
//        }

//        public TEntity Get(TId id)
//        {
//            return dbSet.Find(id);
//        }

//        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> predicate)
//        {
//            return DbContext.Set<TEntity>().Where(predicate);
//        }

//        public IQueryable<TEntity> GetAll()
//        {
//            return DbContext.Set<TEntity>();
//        }

//        public void Remove(TId id)
//        {
//            dbSet.Remove(dbSet.Find(id));
//        }

//        public void Remove(TEntity entity)
//        {
//            dbSet.Remove(entity);
//        }

//        public void Update(TEntity entity)
//        {
//            UpdateEntityForUpdate(entity);
//            dbSet.Update(entity);
//        }

//        public void Update(TEntity entity, string userId)
//        {
//            UpdateEntityForUpdate(entity, userId);
//            dbSet.Update(entity);
//        }

//        protected void UpdateEntityForAdd(IEntityBase<TId> entity)
//        {
//            string userName = _userResolverService.GetUser();
//            entity.CreatedBy = userName;
//            entity.UpdateDate = DateTime.Now;
//            entity.CreateDate = DateTime.Now;

//        }

//        protected void UpdateEntityForAdd(TEntity entity, string userId = "")
//        {
//            if (!string.IsNullOrEmpty(userId))
//            {
//                entity.CreatedBy = userId;
//            }
//            else
//            {
//                string userName = _userResolverService.GetUser();
//                entity.CreatedBy = userName;
//            } 
//            entity.UpdateDate = DateTime.Now;
//            entity.CreateDate = DateTime.Now;

//        }

//        protected void UpdateEntityForUpdate(IEntityBase<TId> entity)
//        {
//            string userName = _userResolverService.GetUser();
//            entity.CreatedBy = userName;
//            entity.UpdateDate = System.DateTime.Now;

//        }

//        protected void UpdateEntityForUpdate(IEntityBase<TId> entity, string userId)
//        {
//            //string userName = _userResolverService.GetUser();
//            entity.CreatedBy = userId;
//            entity.UpdateDate = System.DateTime.Now;

//        }

//        protected void UpdateEntityForUpdate(IEnumerable<IEntityBase<TId>> entities)
//        {
//            foreach (var entity in entities)
//            {
//                string userName = _userResolverService.GetUser();
//                entity.CreatedBy = userName;
//                entity.UpdateDate = System.DateTime.Now;
//            }
//        }

//        public void UpdateTracking(IEntityBase<TId> perm, EntityState state)
//        {
//            dataContext.Entry(perm).State = state;

//            if (state == EntityState.Added)
//            {
//                this.UpdateEntityForAdd(perm);
//            }
//            else
//            {
//                this.UpdateEntityForUpdate(perm);
//            }
//        }

//        public List<T> ExecSQL<T>(string query)
//        {
//            var command = dataContext.Database.GetDbConnection().CreateCommand();
//            command.CommandText = query;
//            command.CommandType = CommandType.Text;
//            dataContext.Database.OpenConnection();
//            List<T> list = new List<T>();
//            using (var result = command.ExecuteReader())
//            {

//                T obj = default(T);
//                while (result.Read())
//                {
//                    obj = Activator.CreateInstance<T>();
//                    foreach (PropertyInfo prop in obj.GetType().GetProperties())
//                    {
//                        if (!object.Equals(result[prop.Name], DBNull.Value))
//                        {
//                            prop.SetValue(obj, result[prop.Name], null);
//                        }
//                    }
//                    list.Add(obj);
//                }
//            }
//            command.Connection.Close();
//            return list;
//        }
//    }

//    public interface IBaseBreezeRepository<TEntity, TId> where TEntity : class, IEntityBase<TId>, new()
//    {
//    }
//}
