using TournXBack.src.modules.Rounds.Models;

namespace TournXBack.src.modules.Rounds.Interfaces
{
    public interface IRoundRepository
    {
        Task<List<Round>> GetAllAsync();
        Task<Round?> GetByIdAsync(int id);
        Task<Round> CreateAsync(RoundRequestDto roundRequestDto);
        Task<Round?> UpdateAsync(int id, RoundRequestDto roundRequestDto);
        Task<Round?> DeleteAsync(int id);
    }
}
