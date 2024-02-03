namespace TournXBack.src.modules.Matches.Models
{
    public class Match
    {
        public int Id  { get; set; }
        public string Description { get; set; } = string.Empty;
        // TeamId
        public int Winner { get; set; }
        // RoundId
        public int Round { get; set; }
        public bool HasWinner { get; set; } = false;
    }
}
