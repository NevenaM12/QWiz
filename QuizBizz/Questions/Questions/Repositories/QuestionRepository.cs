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

        public async Task<IEnumerable<Question>> GetQuestions()
        {
            return await _context.Questions.Find(p => true).ToListAsync();
        }
    }
}
