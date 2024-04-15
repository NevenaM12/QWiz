using ConnectPlayers.Service.Entities;

namespace ConnectPlayers.Service.Services
{
    public interface IMatchService
    {
        Task<QuizMatch> MatchAsync(string player);
        void UpdateMatch(int matchId, string ipAddress, int port, MatchDescription desc);
    }
}
