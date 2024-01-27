namespace TournXBack.src.modules.MatchResults.Models
{
    public class MatchResult
    {
        public int Id { get; set; }
        public string Match { get; set; } = string.Empty;
        public string WinnerTeam { get; set; } = string.Empty;
        public string Result { get; set; } = string.Empty;
    }
}
