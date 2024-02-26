using System.ComponentModel.DataAnnotations;

namespace TournXBack.src.modules.Teams.Models
{
    public class TeamRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Name must be 5 characters")]
        [MaxLength(280, ErrorMessage = "Name cannot be over 280 characters")]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public string Level { get; set; } = string.Empty;
        
        [Required]
        public string Game { get; set; } = string.Empty;
        
        [Required]
        [Range(2, 11)]
        public int MaxPlayers { get; set; }
        
        [Required]
        public string LeaderPlayerId { get; set; } = string.Empty;

        [Required]
        public string[] Players { get; set; } = [];
    }
}
