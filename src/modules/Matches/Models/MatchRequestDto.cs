using System.ComponentModel.DataAnnotations;

namespace TournXBack.src.modules.Matches.Models
{
    public class MatchRequestDto
    {
        [Required]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        public int Winner { get; set; }
        
        [Required]
        public int Round { get; set; }
        
        [Required]
        public bool HasWinner { get; set; }
    }
}
