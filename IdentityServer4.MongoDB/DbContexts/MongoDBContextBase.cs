using IdentityServer4.MongoDB.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;

namespace IdentityServer4.MongoDB.DbContexts
{
    public class MongoDBContextBase : IDisposable
    {
        private readonly IMongoClient _client;

        public MongoDBContextBase(IOptions<MongoDBConfiguration> settings, IHostingEnvironment environment)
        {
            if (settings.Value == null)
                throw new ArgumentNullException(nameof(settings), "MongoDBConfiguration cannot be null.");

            if (settings.Value.ConnectionString == null)
                throw new ArgumentNullException(nameof(settings), "MongoDBConfiguration.ConnectionString cannot be null.");

            if (settings.Value.DatabaseName == null)
                throw new ArgumentNullException(nameof(settings), "MongoDBConfiguration.Database cannot be null.");

            if (environment.IsDevelopment())
                _client = new MongoClient(settings.Value.ConnectionString);
            else
                _client = new MongoClient(settings.Value.ConnectionString);

            Database = _client.GetDatabase(settings.Value.DatabaseName);
        }

        protected IMongoDatabase Database { get; }

        public void Dispose()
        {
            // TODO
        }
    }
}
