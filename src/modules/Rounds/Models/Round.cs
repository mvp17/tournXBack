namespace TournXBack.src.modules.Rounds.Models
{
    public class Round
    {
        public int Id { get; set; }
        public int BestOf { get; set; }
        public int NumTeams { get; set; }
        // Team
        public int Winner { get; set; }
        // Teams
        public int[] Rivals { get; set; } = [];
        // Round
        public int NextRound { get; set; }
        // Tournament
        public int Tournament { get; set; }
        public bool HasWinner { get; set; }
    }
}
