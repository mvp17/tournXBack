using System.ComponentModel.DataAnnotations;

namespace TournXBack.src.modules.TournamentInvitations.Models
{
    public class TournamentInvitationRequestDto
    {
        [Required]
        public int InvitesTo_tournamentId { get; set; }
        
        [Required]
        public int TeamId { get; set; }
        
        [Required]
        public string Message { get; set; } = string.Empty;

        [Required]
        public int Invites_playerId { get; set; }
    }
}
