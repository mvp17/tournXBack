using TournXBack.Teams.Models;

namespace TournXBack.Teams.Interfaces
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetAllAsync();
        Task<Team?> GetByIdAsync(int id);
        Task<Team> CreateAsync(TeamRequestDto teamDto);
        Task<Team?> UpdateAsync(int id, TeamRequestDto teamDto);
        Task<Team?> DeleteAsync(int id);
    }
}
