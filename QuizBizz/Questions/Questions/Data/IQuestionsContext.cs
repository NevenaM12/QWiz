using MongoDB.Driver;
using Questions.Entities;

namespace Questions.Data
{
    public interface IQuestionsContext
    {
        IMongoCollection<Question> Questions { get; }
    }
}
