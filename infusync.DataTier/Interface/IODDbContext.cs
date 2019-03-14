using MongoDB.Driver;

namespace infusync.DataTier
{

    public interface IODDbContext
    {
        IMongoDatabase GetDatabase();
    }

}