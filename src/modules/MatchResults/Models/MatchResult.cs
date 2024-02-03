namespace TournXBack.src.modules.MatchResults.Models
{
    public class MatchResult
    {
        public int Id { get; set; }
        // MatchId
        public int Match { get; set; }
        // TeamId
        public int Winner { get; set; }
        public string Result { get; set; } = string.Empty;
    }
}
