using TournXBack.src.modules.Teams.Models;

namespace TournXBack.src.modules.Rounds.Models
{
    public class RoundTeam
    {
        public int RoundId { get; set; }
        public int TeamId { get; set; }
        public Round? Round { get; set; }
        public Team? Team { get; set; }
    }
}
