using System.ComponentModel.DataAnnotations;

namespace TournXBack.src.modules.MatchResults.Models
{
    public class MatchResultRequestDto
    {
        [Required]
        public int MatchId { get; set; }
        
        [Required]
        public int WinnerTeamId { get; set; }
        
        [MinLength(5, ErrorMessage = "Result must be 5 characters")]
        [MaxLength(256, ErrorMessage = "Result cannot be over 280 characters")]
        [Required]
        public string Result { get; set; } = string.Empty;
    }
}
