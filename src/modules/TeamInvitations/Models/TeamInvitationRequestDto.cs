using System.ComponentModel.DataAnnotations;

namespace TournXBack.src.modules.TeamInvitations.Models
{
    public class TeamInvitationRequestDto
    {
        [Required]
        public int PlayerId { get; set; }
        
        [Required]
        public int TeamId { get; set; }
        
        [Required]
        public string Message { get; set; } = string.Empty;

        [Required]
        public bool Accepted { get; set; }
    }
}
