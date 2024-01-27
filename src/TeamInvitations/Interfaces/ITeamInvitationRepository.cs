using TournXBack.src.TeamInvitations.Models;

namespace TournXBack.src.TeamInvitations.Interfaces
{
    public interface ITeamInvitationRepository
    {
        Task<List<TeamInvitation>> GetAllAsync();
        Task<TeamInvitation?> GetByIdAsync(int id);
        Task<TeamInvitation> CreateAsync(TeamInvitationRequestDto teamInvitationRequestDto);
        Task<TeamInvitation?> UpdateAsync(int id, TeamInvitationRequestDto teamInvitationRequestDto);
        Task<TeamInvitation?> DeleteAsync(int id);
    }
}
