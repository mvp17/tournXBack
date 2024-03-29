using System.ComponentModel.DataAnnotations.Schema;

namespace TournXBack.src.modules.TeamInvitations.Models
{
    [Table("TeamInvitations")]
    public class TeamInvitation
    {
        public int Id { get; set; }
        public string PlayerId { get; set; } = string.Empty;
        public int TeamId { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Accepted { get; set; } = false;
    }
}
