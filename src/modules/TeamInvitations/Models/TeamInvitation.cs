namespace TournXBack.src.modules.TeamInvitations.Models
{
    public class TeamInvitation
    {
        public int Id { get; set; }
        // PlayerId
        public int Player { get; set; }
        // TeamId
        public int Team { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool Accepted { get; set; } = false;
    }
}
