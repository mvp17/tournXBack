namespace TournXBack.Teams.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
        public string Game { get; set; } = string.Empty;
        public int MaxPlayers { get; set; }
    }
}
