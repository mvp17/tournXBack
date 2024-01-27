using TournXBack.src.core.Models;

namespace TournXBack.src.core.Services
{
    public interface ITokenService
    {
        string? CreateToken(User user);
    }
}
