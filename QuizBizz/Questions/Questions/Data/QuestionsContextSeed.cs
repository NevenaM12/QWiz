using MongoDB.Driver;
using Questions.Entities;

namespace Questions.Data
{
    public class QuestionsContextSeed
    {
        public static void SeedData(IMongoCollection<Question> questionCollection)
        {
            //nadji sve proizvode
            var existQuestion = questionCollection.Find(p => true).Any();
            if (!existQuestion)
            {
                questionCollection.InsertManyAsync(GetPreconfiguredQuestions());
            }
        }

        private static IEnumerable<Question> GetPreconfiguredQuestions()
        {
            return new List<Question>()
            {
                new Question()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Category = "geography",
                    DificultyLevel = "easy",
                    QuestionTitle = "What is the capital of France?",
                    Option1 = "Rome",
                    Option2 = "Berlin",
                    Option3 = "Paris",
                    Option4 = "Madrid",
                    RightAnswer = "Paris"
                },
                new Question()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Category = "history",
                    DificultyLevel = "easy",
                    QuestionTitle = "In which year did World War II end?",
                    Option1 = "1943",
                    Option2 = "1945",
                    Option3 = "1950",
                    Option4 = "1939",
                    RightAnswer = "1945"
                },
                new Question()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Category = "geography",
                    DificultyLevel = "medium",
                    QuestionTitle = "Which planet is known as the 'Red Planet'?",
                    Option1 = "Venus",
                    Option2 = "Mars",
                    Option3 = "Jupiter",
                    Option4 = "Saturn",
                    RightAnswer = "Mars"
                }
            };
        }
    }
}
