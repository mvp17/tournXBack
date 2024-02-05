using System.ComponentModel.DataAnnotations.Schema;

namespace TournXBack.src.modules.MatchResults.Models
{
    [Table("MatchResults")]
    public class MatchResult
    {
        public int Id { get; set; }
        public int MatchId { get; set; }
        public int WinnerTeamId { get; set; }
        public string Result { get; set; } = string.Empty;
    }
}
