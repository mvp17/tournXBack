using System.ComponentModel.DataAnnotations;

namespace TournXBack.src.modules.MatchResults.Models
{
    public class MatchResultRequestDto
    {
        [Required]
        public string Match { get; set; } = string.Empty;
        
        [Required]
        public string Winner { get; set; } = string.Empty;
        
        [MinLength(5, ErrorMessage = "Result must be 5 characters")]
        [MaxLength(256, ErrorMessage = "Result cannot be over 280 characters")]
        [Required]
        public string Result { get; set; } = string.Empty;
    }
}
