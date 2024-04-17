using CatalogTopics.Data;
using CatalogTopics.Entities;
using MongoDB.Driver;

namespace CatalogTopics.Repositories
{
    public class TopicsRepository : ITopicsRepository
    {
        private readonly ITopicsContext _context;

        public TopicsRepository(ITopicsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<Topic>> GetTopics()
        {
           return await _context.Topics.Find(p=>true).ToListAsync();
        }
        public async Task<Topic> GetTopicByName(string topicName)
        {
            return await _context.Topics.Find(p => p.TopicName == topicName).FirstOrDefaultAsync();
        }

        public async Task CreateTopic(Topic topic)
        {
            await _context.Topics.InsertOneAsync(topic);
        }

        public async Task<bool> DeleteTopic(string id)
        {
            var deleteResult = await _context.Topics.DeleteOneAsync(p => p.Id == id);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

        //mislim da nam UpdateTopic nece trebati
        public async Task<bool> UpdateTopic(Topic topic)
        {
            var updateResult = await _context.Topics.ReplaceOneAsync(p => p.Id == topic.Id, topic);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
