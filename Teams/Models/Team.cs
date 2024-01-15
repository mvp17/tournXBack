namespace TournXBack.Teams.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Level { get; set; }
        public string? Game { get; set; }
        public int MaxPlayers { get; set; }
    }
}
