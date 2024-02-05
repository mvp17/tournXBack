using System.ComponentModel.DataAnnotations.Schema;

namespace TournXBack.src.modules.Matches.Models
{
    [Table("Matches")]
    public class Match
    {
        public int Id  { get; set; }
        public string Description { get; set; } = string.Empty;
        public int WinnerTeamId { get; set; }
        public int RoundId { get; set; }
        public bool HasWinner { get; set; } = false;
    }
}
