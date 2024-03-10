using System.ComponentModel.DataAnnotations.Schema;

namespace TournXBack.src.modules.TournamentInvitations.Models
{
    [Table("TournamentInvitations")]
    public class TournamentInvitation
    {
        public int Id { get; set; }
        public int InvitesTo_tournamentId { get; set; }
        public int TeamId { get; set; }
        public string Message { get; set; } = string.Empty;
        public string Invites_playerId { get; set; } = string.Empty;
    }
}
