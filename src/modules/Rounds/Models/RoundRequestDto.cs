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
        public int Winner { get; set; }
        
        [Required]
        public int[] Rivals { get; set; } = [];
        
        [Required]
        public int NextRound { get; set; }
        
        [Required]
        public int Tournament { get; set; }
        
        [Required]
        public bool HasWinner { get; set; }
    }
}
