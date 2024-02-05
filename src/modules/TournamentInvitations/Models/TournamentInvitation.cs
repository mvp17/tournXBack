using System.ComponentModel.DataAnnotations.Schema;

namespace TournXBack.src.modules.TournamentInvitations.Models
{
    [Table("TournamentInvitations")]
    public class TournamentInvitation
    {
        public int Id { get; set; }
        public int InvitesTo_tournamentId { get; set; }
        public string Team { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public int Invites_playerId { get; set; }
    }
}
