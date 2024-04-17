using CatalogTopics.Entities;
using CatalogTopics.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CatalogTopics.Controllers
{
    [ApiController]
    [Route("api/v2/[controller]")]
    public class TopicController:ControllerBase
    {
            private readonly ITopicsRepository _repository;

            public TopicController(ITopicsRepository repository)
            {
                _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            }

            [HttpGet]
            [ProducesResponseType(typeof(IEnumerable<Topic>), StatusCodes.Status200OK)]
            public async Task<ActionResult<IEnumerable<Topic>>> GetTopics()
            {
                var Topics = await _repository.GetTopics();
                return Ok(Topics);
            }

            [HttpGet("{topicName}", Name = "GetTopic")]
            [ProducesResponseType(typeof(Topic), StatusCodes.Status200OK)]
            [ProducesResponseType(typeof(Topic), StatusCodes.Status404NotFound)]
            public async Task<ActionResult<Topic>> GetTopicByName(string topicName)
            {
                var Topic = await _repository.GetTopicByName(topicName);
                if (Topic == null)
                {
                    return NotFound(null);
                }
                return Ok(Topic);
            }

            [HttpPost(Name ="CreateTopic")]
            [ProducesResponseType(typeof(IEnumerable<Topic>), StatusCodes.Status201Created)]
            public async Task<ActionResult<Topic>> CreateTopic([FromBody] Topic Topic)
            {
                await _repository.CreateTopic(Topic);

                return CreatedAtRoute("GetTopic", new { id = Topic.Id }, Topic);
            }

            [HttpPut(Name ="UpdateTopic")]
            [ProducesResponseType(typeof(Topic), StatusCodes.Status200OK)]
            public async Task<IActionResult> UpdateTopic([FromBody] Topic Topic)
            {
                return Ok(await _repository.UpdateTopic(Topic));
            }

            [HttpDelete("{id}", Name = "DeleteTopic")]
            [ProducesResponseType(typeof(Topic), StatusCodes.Status200OK)]
            public async Task<IActionResult> DeleteTopicById(string id)
            {
                return Ok(await _repository.DeleteTopic(id));
            }
        }
    }
