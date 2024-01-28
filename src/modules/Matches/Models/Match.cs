namespace TournXBack.src.modules.Matches.Models
{
    public class Match
    {
        public int Id  { get; set; }
        public string Description { get; set; } = string.Empty;
        // Team
        public int Winner { get; set; }
        // Round
        public int Round { get; set; }
        public bool HasWinner { get; set; }
    }
}
