using MongoDB.Driver;

namespace IdentityServer4.MongoDB.Configuration
{
    public class MongoDBConfiguration
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string AuthKey { get; set; }
        public string MongoUrl { get; set; }
        public string LocalConnectionString { get; set; }
    }
}
