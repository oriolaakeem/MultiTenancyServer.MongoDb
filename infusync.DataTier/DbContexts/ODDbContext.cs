using IdentityServer4.MongoDB.Configuration;
using IdentityServer4.MongoDB.DbContexts;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace infusync.DataTier.DbContexts
{
    public class ODDbContext : MongoDBContextBase, IODDbContext
    {
        private MongoClient _client;
        public string _database;
        public ODDbContext(IOptions<MongoDBConfiguration> settings, IHostingEnvironment env)
            : base(settings, env)
        {
            if (env.IsDevelopment())
                _client = new MongoClient(settings.Value.ConnectionString);
            else
                _client = new MongoClient(settings.Value.ConnectionString);

            _database = settings.Value.DatabaseName;
        }
        public IMongoDatabase GetDatabase()
        {
            return _client.GetDatabase(_database);
        }
    }
}
