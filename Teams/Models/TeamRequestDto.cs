namespace TournXBack.Teams.Models
{
    public class TeamRequestDto
    {
        public string? Name { get; set; }
        public string? Level { get; set; }
        public string? Game { get; set; }
        public int MaxPlayers { get; set; }
    }
}
