using TournXBack.src.modules.Players.Models;

namespace TournXBack.src.modules.Teams.Models
{
    public class TeamPlayer
    {
        public int TeamId { get; set; }
        public int PlayerId { get; set; }
        public Team? Team { get; set; }
        public Player? Player { get; set; }
    }
}
