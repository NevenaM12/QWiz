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
        public async Task<ActionResult<IEnumerable<Question>>> GetAllQuestions()
        {
            var questions = await _repository.GetAllQuestions();
            return Ok(questions);
        }

        [Route("[action]/{topic}")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Question>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestionsByTopic(string topic)
        {
            var questions = await _repository.GetQuestionsByTopic(topic);
            return Ok(questions);
        }

        [ActionName("GetQuestion")]
        [HttpPost]
        [ProducesResponseType(typeof(Question), StatusCodes.Status201Created)]
        public async Task<ActionResult<Question>> CreateQuestion([FromBody] Question Question)
        {
            await _repository.CreateQuestion(Question);

            return CreatedAtAction("GetQuestion", new { id = Question.Id }, Question);
        }

        [HttpPut]
        [ProducesResponseType(typeof(Question), StatusCodes.Status200OK)]
        public async Task<ActionResult<Question>> UpdateQuestion([FromBody] Question Question)
        {
            return Ok(await _repository.UpdateQuestion(Question));
        }

        [HttpDelete("{id:length(24)}", Name = "DeleteQuestion")]
        [ProducesResponseType(typeof(Question), StatusCodes.Status200OK)]
        public async Task<ActionResult<Question>> DeleteQuestion(string id)
        {
            return Ok(await _repository.DeleteQuestion(id));
        }
    }
}

