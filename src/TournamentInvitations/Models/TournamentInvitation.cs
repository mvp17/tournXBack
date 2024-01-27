namespace TournXBack.src.TournamentInvitations.Models
{
    public class TournamentInvitation
    {
        public int Id { get; set; }
        public string Tournament { get; set; } = string.Empty;
        public string Team { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
