using ConnectPlayers.Service.Entities;
using ConnectPlayers.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlayers.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConnectController : ControllerBase
    {
       
        [HttpGet(Name ="ConnectPlayers")]
        [ProducesResponseType(typeof(QuizMatch), StatusCodes.Status200OK)]
        public async Task<ActionResult<QuizMatch>> ConnectPlayers(string player,IMatchService matchService)
        {
            var quizMatch = await matchService.MatchAsync(player);
            return Ok(quizMatch);
        }
    }
}
