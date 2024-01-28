namespace TournXBack.src.modules.Matches.Models
{
    public class Match
    {
        public int Id  { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Winner { get; set; } = string.Empty;
        public string Round { get; set; } = string.Empty;
    }
}
