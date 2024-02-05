using TournXBack.src.modules.Teams.Models;

namespace TournXBack.src.modules.Tournaments.Models
{
    public class TournamentTeam
    {
        public int TournamentId { get; set; }
        public int TeamId { get; set; }
        public Tournament? Tournament { get; set; }
        public Team? Team { get; set; }
    }
}
