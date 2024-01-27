using TournXBack.src.modules.Tournaments.Models;

namespace TournXBack.src.modules.Tournaments.Interfaces
{
    public interface ITournamentRepository
    {
        Task<List<Tournament>> GetAllAsync();
        Task<Tournament?> GetByIdAsync(int id);
        Task<Tournament> CreateAsync(TournamentRequestDto tournamentDto);
        Task<Tournament?> UpdateAsync(int id, TournamentRequestDto tournamentDto);
        Task<Tournament?> DeleteAsync(int id);
    }
}
