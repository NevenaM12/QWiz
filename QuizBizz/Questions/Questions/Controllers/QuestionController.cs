using Microsoft.AspNetCore.Mvc;
using Questions.Entities;
using Questions.Repositories;

namespace Questions.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _repository;

        public QuestionController(IQuestionRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Question>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions()
        {
            var questions = await _repository.GetQuestions();
            return Ok(questions);
        }
    }
}

