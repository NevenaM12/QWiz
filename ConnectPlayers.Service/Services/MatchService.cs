using ConnectPlayers.Service.Entities;
using ClassLibrary.Common;
using MassTransit;
using System.Numerics;
using static ClassLibrary.Common.Contracts;

namespace ConnectPlayers.Service.Services
{
    public class MatchService : IMatchService
    {
        private static List<QuizMatch> _matches = new List<QuizMatch>();
        private readonly IBus bus;

        public MatchService(IBus bus)
        {
            this.bus = bus;
        }
        private int matchId = 1;
        public async Task<QuizMatch> MatchAsync(string player) //treba nam ovaj Async za komunikaciju sa drugim mikroservisima
        {     
            var waitingMatch = _matches.FirstOrDefault(match => match.PlayerB == player || match.PlayerA == player);

            if(waitingMatch != null)
            { 
                return await Task.FromResult(waitingMatch);
            }
            var openMatch = _matches.FirstOrDefault(match => match.PlayerB == null || match.matchDescription==MatchDescription.JustPlayerA); // playerA wants to play and we're trying to find playerB 
            
            if (openMatch!=null)
            {//there exist an openMatch meaning playerA is waiting
                
                openMatch.PlayerB = player;
                openMatch.matchDescription = MatchDescription.PlayersConnected; //quizReady=1
                //we want to publish a message that gamemanager can see and use
                await bus.Publish(new MatchWaitingForGame(openMatch.Id));
                
                return openMatch;

            }
            else
            {
                var newMatch = new QuizMatch { Id = matchId++, PlayerA = player, matchDescription = MatchDescription.QuizReady };
                _matches.Add(newMatch);
                return newMatch;
}
        }
        //method to update match ip address,port and state
        public void UpdateMatch(int matchId, string ipAddress,int port, MatchDescription desc)
        {
            var match = _matches.FirstOrDefault(m => m.Id == matchId);
            if(match != null)
            {
                match.IpAddress = ipAddress;
                match.Port = port;
                match.matchDescription = desc;
            }
            else
            {
                throw new ArgumentException($"**Match with id {matchId} not found", nameof(matchId));
            }

        }
    }
   }
