using TournXBack.Players.Models;

namespace TournXBack.src.Players.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(Player player);
    }
}