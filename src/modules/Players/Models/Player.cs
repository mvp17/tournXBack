using TournXBack.src.core.Models;
using TournXBack.src.modules.Teams.Models;

namespace TournXBack.src.modules.Players.Models 
{
    public class Player : User
    {
        public List<TeamPlayer> TeamPlayers { get; set; } = [];
    }
}
