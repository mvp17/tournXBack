using TournXBack.src.MatchResults.Models;

namespace TournXBack.src.MatchResults.Interfaces
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
