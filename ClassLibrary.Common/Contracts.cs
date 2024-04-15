namespace ClassLibrary.Common
{
    public class Contracts
    {
        //1.ConnectPlayers sends the message that match is created and it's waiting for a game
        //2.GameManager sends message back to ConnectPlayers
        public record MatchWaitingForGame(int MatchId);
        public record QuizCreated(Guid QuizId,int MatchId,string IpAddress, int Port);
        //Guid - globally unique identifier
    }
}
