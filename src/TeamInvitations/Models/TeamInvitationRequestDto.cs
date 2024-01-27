using System.ComponentModel.DataAnnotations;

namespace TournXBack.src.TeamInvitations.Models
{
    public class TeamInvitationRequestDto
    {
        [Required]
        public string Player { get; set; } = string.Empty;
        
        [Required]
        public string Team { get; set; } = string.Empty;
        
        [Required]
        public string Message { get; set; } = string.Empty;
    }
}
