using System.ComponentModel.DataAnnotations;

namespace TournXBack.src.MatchResults.Models
{
    public class MatchResultRequestDto
    {
        [Required]
        public string Match { get; set; } = string.Empty;
        
        [Required]
        public string WinnerTeam { get; set; } = string.Empty;
        
        [Required]
        public string Result { get; set; } = string.Empty;
    }
}
