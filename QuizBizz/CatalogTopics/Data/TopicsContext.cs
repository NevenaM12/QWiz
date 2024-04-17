using CatalogTopics.Entities;
using MongoDB.Driver;

namespace CatalogTopics.Data
{
    public class TopicsContext : ITopicsContext
    {
        public TopicsContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase("TopicsDB");

            Topics = database.GetCollection<Topic>("Topics");
            TopicsContextSeed.SeedData(Topics);
        }
        public IMongoCollection<Topic> Topics { get; }
    }
}
