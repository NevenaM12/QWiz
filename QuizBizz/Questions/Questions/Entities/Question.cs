using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Questions.Entities
{
    public class Question
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Topic { get; set; }
        public string DificultyLevel { get; set; }
        public string QuestionTitle { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public string RightAnswer { get; set; }
    }

}
