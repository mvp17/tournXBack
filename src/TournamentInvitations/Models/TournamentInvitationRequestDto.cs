using System.ComponentModel.DataAnnotations;

namespace TournXBack.src.TournamentInvitations.Models
{
    public class TournamentInvitationRequestDto
    {
        [Required]
        public string Tournament { get; set; } = string.Empty;
        
        [Required]
        public string Team { get; set; } = string.Empty;
        
        [Required]
        public string Message { get; set; } = string.Empty;
    }
}
