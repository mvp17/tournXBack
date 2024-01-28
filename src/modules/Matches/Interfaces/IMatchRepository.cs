using TournXBack.src.modules.Matches.Models;

namespace TournXBack.src.modules.Matches.Interfaces
{
    public interface IMatchRepository
    {
        Task<List<Match>> GetAllAsync();
        Task<Match?> GetByIdAsync(int id);
        Task<Match> CreateAsync(MatchRequestDto matchResultRequestDto);
        Task<Match?> UpdateAsync(int id, MatchRequestDto matchResultRequestDto);
        Task<Match?> DeleteAsync(int id);
    }
}
