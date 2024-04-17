using CatalogTopics.Entities;
using MongoDB.Driver;

namespace CatalogTopics.Data
{
    public interface ITopicsContext
    {
        IMongoCollection<Topic> Topics { get; }
    }
}
