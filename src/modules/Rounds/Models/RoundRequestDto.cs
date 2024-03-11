using System.ComponentModel.DataAnnotations;

namespace TournXBack.src.modules.Rounds.Models
{
    public class RoundRequestDto
    {
        [Required]
        public int BestOf { get; set; }
        
        [Required]
        public int NumTeams { get; set; }

        [Required]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        public int WinnerTeamId { get; set; }
        
        [Required]
        public int[] Rivals { get; set; } = [];
        
        public int? NextRoundId { get; set; }
        
        [Required]
        public int TournamentId { get; set; }
        
        [Required]
        public bool HasWinner { get; set; }
    }
}
