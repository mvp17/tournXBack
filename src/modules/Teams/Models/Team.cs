using System.ComponentModel.DataAnnotations.Schema;

namespace TournXBack.src.modules.Teams.Models
{
    [Table("Teams")]
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Level { get; set; } = string.Empty;
        public string Game { get; set; } = string.Empty;
        public int MaxPlayers { get; set; }
        public int LeaderPlayerId { get; set; }
        // Many to Many
        public int[] Players { get; set; } = [];
    }
}
