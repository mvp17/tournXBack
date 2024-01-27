using TournXBack.src.Players.Models;

namespace TournXBack.src.Players.Interfaces
{
    public interface IPlayerRepository
    {
        Task<List<Player>> GetAllAsync();
        Task<Player?> GetByIdAsync(int id);
        Task<Player> CreateAsync(PlayerRequestDto playerDto);
        Task<Player?> UpdateAsync(int id, PlayerRequestDto playerDto);
        Task<Player?> DeleteAsync(int id);
    }
}
