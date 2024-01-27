using TournXBack.src.modules.MatchResults.Models;

namespace TournXBack.src.modules.MatchResults.Interfaces
{
    public interface IMatchResultRepository
    {
        Task<List<MatchResult>> GetAllAsync();
        Task<MatchResult?> GetByIdAsync(int id);
        Task<MatchResult> CreateAsync(MatchResultRequestDto matchResultRequestDto);
        Task<MatchResult?> UpdateAsync(int id, MatchResultRequestDto matchResultRequestDto);
        Task<MatchResult?> DeleteAsync(int id);
    }
}
