namespace TournXBack.src.modules.Tournaments.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
        public string Game { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int MinParticipants { get; set; }
        public int MaxParticipants { get; set; }
        public int MinTeamPlayers { get; set; }
        public int MaxTeamPlayers { get; set; }
    }
}
