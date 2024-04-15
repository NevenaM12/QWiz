
namespace ConnectPlayers.Service.Entities
{
    public class QuizMatch
    {
        public int Id { get; set; }
        public required string PlayerA {  get; set; }
        public string? PlayerB { get; set; }
        public MatchDescription matchDescription { get; set; }
        public string? IpAddress {  get; set; } //it will not be set when the game is made

        public int? Port { get; set; }

    }
    public enum MatchDescription
    {
        JustPlayerA,
        PlayersConnected,
        QuizReady
    }
    }
   
