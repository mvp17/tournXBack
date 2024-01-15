using System.ComponentModel.DataAnnotations;

namespace TournXBack.src.Players.Models
{
    public class LoginDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
