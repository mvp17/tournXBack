namespace TournXBack.src.modules.Matches.Models
{
    public class MatchRequestDto
    {
        public string Description { get; set; } = string.Empty;
        public string Winner { get; set; } = string.Empty;
        public string Round { get; set; } = string.Empty;
    }
}
