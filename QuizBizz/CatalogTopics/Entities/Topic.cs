using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace CatalogTopics.Entities
{
    public class Topic
    {

        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string TopicName { get; set; }

        //public IEnumerable<Question> listOfQuestions
        
    }
}

