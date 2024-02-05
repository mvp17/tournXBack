using System.ComponentModel.DataAnnotations;

namespace TournXBack.src.modules.Matches.Models
{
    public class MatchRequestDto
    {
        [Required]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        public int WinnerTeamId { get; set; }
        
        [Required]
        public int RoundId { get; set; }
        
        [Required]
        public bool HasWinner { get; set; }
    }
}
