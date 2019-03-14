using Humanizer;
using MongoDB.Bson;
using MongoDB.Driver;
using OryxDomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace infusync.DataTier
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase<ObjectId>, new()
    {
        protected static IODDbContext _context;
        protected static IMongoCollection<T> _collection;

        public Repository(IODDbContext context)
        {
            _context = context;

            if (typeof(T).Name == "ApplicationUser")
            {
                _collection = _context.GetDatabase().GetCollection<T>("applicationUsers");
            }
            else if (typeof(T).Name == "ApplicationRole")
            {
                _collection = _context.GetDatabase().GetCollection<T>("applicationRoles");
            }
            else
            {
                _collection = _context.GetDatabase().GetCollection<T>(typeof(T).Name.Pluralize().Replace(_context.GetDatabase().ToString() + ".", "").ToLower());
            }
        }

        public IMongoCollection<T> Collection { get { return _collection; } }

        public Task Add(T item)
        {
            return Collection.InsertOneAsync(item);
        }

        public Task Add(T item, string userId)
        {
            //if (!string.IsNullOrEmpty(userId))
            //{
            //    item.CreatedBy = userId;
            //}
            return Collection.InsertOneAsync(item);
        }

        public IEnumerable<T> All()
        {
            return Collection.AsQueryable();
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> filter)
        {
            return All().AsQueryable().Where(filter);
        }

        public T Get(ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("Id", id);
            return Collection.Find(filter).FirstOrDefault();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return Find(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return All();
        }

        public Task Remove(ObjectId id)
        {
            return Collection.DeleteOneAsync(Builders<T>.Filter.Eq("Id", id));
        }

        public T Single(Expression<Func<T, bool>> expression)
        {
            return All().AsQueryable().Where(expression).SingleOrDefault();
        }

        public Task Update(ObjectId id, T body)
        {
            try
            {


                var filter = Builders<T>.Filter.Eq("Id", id);
                return Collection.ReplaceOneAsync(filter, body, new UpdateOptions { IsUpsert = true });
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public Task Update(T body)
        {
            return Update(body.Id, body);
        }
    }
}