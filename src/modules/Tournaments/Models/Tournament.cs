using TournXBack.src.modules.Tournaments.Models.enums;

namespace TournXBack.src.modules.Tournaments.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Level Level { get; set; }
        public string Game { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int MinParticipants { get; set; }
        public int MaxParticipants { get; set; }
        public int MinTeamPlayers { get; set; }
        public int MaxTeamPlayers { get; set; }
        // Many to Many
        // Teams
        public int[] Participants { get; set; } = [];
        // TeamId
        public int Team { get; set; }
        public int BestOf { get; set; }
        public TournamentState State { get; set; } = TournamentState.UNINITIALIZED;
    }
}
