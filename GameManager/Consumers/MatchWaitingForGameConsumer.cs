using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static ClassLibrary.Common.Contracts;

namespace GameManager.Consumers
{
    internal class MatchWaitingForGameConsumer : IConsumer<MatchWaitingForGame>
    {
        private readonly ILogger<MatchWaitingForGameConsumer> _logger;

        public MatchWaitingForGameConsumer(ILogger<MatchWaitingForGameConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<MatchWaitingForGame> context)
        {
            //capturing the message from ConnectPlayers
            var receivedMessage = context.Message;
            _logger.LogInformation("Received MatchWaitingForGame message for match:{MatchId}",receivedMessage.MatchId);
            //TODO: Implement the game provisioning magic here
            await Task.Delay(TimeSpan.FromSeconds(5));

            //getting message back
            var outgoingMessage = new QuizCreated(
                QuizId: Guid.NewGuid(),
                MatchId: receivedMessage.MatchId,
                IpAddress: GenerateRandomIpAdress(),
                Port: GenerateRandomPort()
                );
            _logger.LogInformation("Quiz {QuizId} creted at {IpAddress}:{Port} for match {MatchId}",
                outgoingMessage.QuizId,
                outgoingMessage.IpAddress,
                outgoingMessage.Port,
                outgoingMessage.MatchId);
            await context.Publish(outgoingMessage);
        }
        private static string GenerateRandomIpAdress()
        {
            var random = new Random();
            var ipAddress = new byte[4];
            random.NextBytes(ipAddress);
            return new IPAddress(ipAddress).ToString();
        }
        //Generate a valid random port number
        private static int GenerateRandomPort()
        {
            var random = new Random();
            return random.Next(1024, 65535);
        }
    }
}
