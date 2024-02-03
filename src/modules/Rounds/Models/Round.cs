namespace TournXBack.src.modules.Rounds.Models
{
    public class Round
    {
        public int Id { get; set; }
        public int BestOf { get; set; } = 1;
        public int NumTeams { get; set; } = 2;
        // TeamId
        public int Winner { get; set; }
        // Many to Many
        // Teams
        public int[] Rivals { get; set; } = [];
        // One to One
        // Round
        public int NextRound { get; set; }
        // TournamentId
        public int Tournament { get; set; }
        public bool HasWinner { get; set; } = false;
    }
}
