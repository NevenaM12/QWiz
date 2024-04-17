using CatalogTopics.Entities;

namespace CatalogTopics.Repositories
{
    public interface ITopicsRepository
    {
        Task<IEnumerable<Topic>> GetTopics();
        Task<Topic> GetTopicByName(string topicName);
        Task CreateTopic(Topic topic);
        Task<bool> UpdateTopic(Topic topic);
        Task<bool> DeleteTopic(string id);
    }
}
