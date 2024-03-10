using System.ComponentModel.DataAnnotations.Schema;

namespace TournXBack.src.modules.Teams.Models
{
    [Table("Teams")]
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }
        public string Game { get; set; } = string.Empty;
        public int MaxPlayers { get; set; }
        public string LeaderPlayerId { get; set; } = string.Empty;
        // Many to Many
        public string[] Players { get; set; } = [];
    }
}
