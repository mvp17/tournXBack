using System.ComponentModel.DataAnnotations;

namespace TournXBack.src.core.Models
{
    public class UserRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Username must be 5 characters")]
        [MaxLength(280, ErrorMessage = "Username cannot be over 280 characters")]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
