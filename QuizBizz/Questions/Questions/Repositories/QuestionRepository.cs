using MongoDB.Driver;
using Questions.Data;
using Questions.Entities;

namespace Questions.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly IQuestionsContext _context;

        public QuestionRepository(IQuestionsContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Question>> GetAllQuestions()
        {
            return await _context.Questions.Find(p => true).ToListAsync();
        }

        public async Task<IEnumerable<Question>> GetQuestionsByTopic(string topic)
        {
            return await _context.Questions.Find(p => p.Topic == topic).ToListAsync();
        }

        public async Task CreateQuestion(Question question)
        {
            await _context.Questions.InsertOneAsync(question);

        }

        public async Task<bool> UpdateQuestion(Question question)
        {
            var updateResult = await _context.Questions.ReplaceOneAsync(p => p.Id == question.Id, question); //sta menjam, cime menjam
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<bool> DeleteQuestion(string id)
        {
            var deleteResult = await _context.Questions.DeleteOneAsync(p => p.Id == id);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}
