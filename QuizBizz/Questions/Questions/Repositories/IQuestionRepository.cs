using Questions.Entities;

namespace Questions.Repositories
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetQuestions();

        //Task<Question> GetQuesiton(string id);
        //Task<IEnumerable<Question>> GetProductsByCategory(string categoryName);
        //Task CreateProduct(Question question);
        //Task<bool> UpdateProduct(Question question);
        //Task<bool> DeleteProduct(string id);
    }
}
