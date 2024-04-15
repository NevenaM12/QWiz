using ConnectPlayers.Service.Entities;
using ConnectPlayers.Service.Services;
using MassTransit;
using static ClassLibrary.Common.Contracts;

namespace ConnectPlayers.Service.Consumers
{
    public class GameCreatedConsumer : IConsumer<QuizCreated>
    {
        private readonly IMatchService _matchService;
        private readonly ILogger<GameCreatedConsumer> _logger;
        //get message, update match with information
        public GameCreatedConsumer(IMatchService matchService,ILogger<GameCreatedConsumer> logger)
        {
            this._matchService = matchService;
            _logger = logger;
        }
        public Task Consume(ConsumeContext<QuizCreated> context)
        {
            var message = context.Message;
            _logger.LogInformation("GameCreated message received for match {MatchId}",message.MatchId);
            _matchService.UpdateMatch(message.MatchId, message.IpAddress, message.Port, MatchDescription.QuizReady);
            _logger.LogInformation("Game ready for match {MatchId} at {IpAddress}:{Port}",message.MatchId,message.IpAddress,message.Port);
            return Task.CompletedTask;
        }
    }
}
