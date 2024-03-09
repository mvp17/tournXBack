using Microsoft.AspNetCore.Identity;
namespace TournXBack.src.core.Services
{
    public interface ITokenService
    {
        string? CreateToken(IdentityUser user, IList<string> roles);
    }
}
