using TournXBack.src.modules.Players.Models;

namespace TournXBack.src.modules.Players.interfaces
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetAllAsync();
    }
}