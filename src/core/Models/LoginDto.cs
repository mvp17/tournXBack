using System.ComponentModel.DataAnnotations;

namespace TournXBack.src.core.Models
{
    public class LoginDto
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
