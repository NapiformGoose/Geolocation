using Geolocation.ObjectStorage.Api.Data;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Geolocation.ObjectStorage.Core
{
    public class DbContext
    {
        public IMongoClient Client { get; }

        public IMongoDatabase Database { get; }

        public DbContext(IOptions<DatabaseSettings> dbOptions)
        {
            var settings = dbOptions.Value;
            Client = new MongoClient(settings.ConnectionString);
            Database = Client.GetDatabase(settings.DatabaseName);
        }
    }
}
