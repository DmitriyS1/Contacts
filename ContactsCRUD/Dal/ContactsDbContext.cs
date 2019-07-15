using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace ContactsApi.Dal
{
    public class ContactsDbContext<T>
    {
        private readonly IMongoDatabase _database;
        private readonly IGridFSBucket _gridFS;
        private readonly IConfiguration _configuration;

        public ContactsDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
            var dbConnection = _configuration["MongoDBConection:ConectionString"];
            var dbName = _configuration["MongoDBConection:Database"];
            var connectionString = string.Concat(dbConnection, "/", dbName);
            var connection = new MongoUrlBuilder(connectionString);
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(connection.DatabaseName);
            _gridFS = new GridFSBucket(_database);
        }

        public IMongoCollection<T> GetCollection(string collectionName)
        {
            return _database.GetCollection<T>(collectionName);
        }
    }
}
