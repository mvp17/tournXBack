namespace TournXBack.src.TeamInvitations.Models
{
    public class TeamInvitation
    {
        public int Id { get; set; }
        public string Player { get; set; } = string.Empty;
        public string Team { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}
