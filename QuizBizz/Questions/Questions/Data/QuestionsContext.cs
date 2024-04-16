using MongoDB.Driver;
using Questions.Entities;

namespace Questions.Data
{
    public class QuestionsContext : IQuestionsContext
    {
        public QuestionsContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase("QuestionsDB");

            Questions = database.GetCollection<Question>("Questions");
            QuestionsContextSeed.SeedData(Questions);
        }
        public IMongoCollection<Question> Questions { get; }
    }
}
