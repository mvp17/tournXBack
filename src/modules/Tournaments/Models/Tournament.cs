using TournXBack.src.modules.Tournaments.Models.enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace TournXBack.src.modules.Tournaments.Models
{
    [Table("Tournaments")]
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
        public List<TournamentTeam> Participants { get; set; } = [];
        public int TeamId { get; set; }
        public int BestOf { get; set; }
        public TournamentState State { get; set; } = TournamentState.UNINITIALIZED;
    }
}
