using System.ComponentModel.DataAnnotations.Schema;

namespace TournXBack.src.modules.Rounds.Models
{
    [Table("Rounds")]
    public class Round
    {
        public int Id { get; set; }
        public int BestOf { get; set; } = 1;
        public int NumTeams { get; set; } = 2;
        public int WinnerTeamId { get; set; }
        public int[] Rivals { get; set; } = [];
        // One to One
        public int? NextRoundId { get; set; }
        public int TournamentId { get; set; }
        public bool HasWinner { get; set; } = false;
    }
}
