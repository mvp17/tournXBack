using System.ComponentModel.DataAnnotations;
using TournXBack.src.modules.Tournaments.Models.enums;

namespace TournXBack.src.modules.Tournaments.Models
{
    public class TournamentRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Name must be 5 characters")]
        [MaxLength(280, ErrorMessage = "Name cannot be over 280 characters")]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public Level Level { get; set; }
        
        [Required]
        public string Game { get; set; } = string.Empty;
        
        [Required]
        public string Type { get; set; } = string.Empty;
        
        [Required]
        public string Description { get; set; } = string.Empty;
        
        [Required]
        public int MinParticipants { get; set; }
        
        [Required]
        public int MaxParticipants { get; set; }
        
        [Required]
        public int MinTeamPlayers { get; set; }
        
        [Required]
        public int MaxTeamPlayers { get; set; }

        [Required]
        public int[] Participants { get; set; } = [];
        
        [Required]
        public int WinnerTeamId { get; set; }
        
        [Required]
        public int BestOf { get; set; }
        
        public TournamentState? State { get; set; }
    }
}
