namespace TournXBack.src.modules.TournamentInvitations.Models
{
    public class TournamentInvitation
    {
        public int Id { get; set; }
        // TournamentId
        public int InvitesTo { get; set; }
        public string Team { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        // PlayerId
        public int Invites { get; set; }
    }
}
