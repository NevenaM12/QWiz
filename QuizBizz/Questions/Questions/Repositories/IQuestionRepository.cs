using Questions.Entities;

namespace Questions.Repositories
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetAllQuestions();

        //Task<Question> GetQuesiton(string id);
        Task<IEnumerable<Question>> GetQuestionsByTopic(string topic);
        Task CreateQuestion(Question question);
        Task<bool> UpdateQuestion(Question question);
        Task<bool> DeleteQuestion(string id);
    }
}
