using TournXBack.src.TournamentInvitations.Models;

namespace TournXBack.src.TournamentInvitations.Interfaces
{
    public interface ITournamentInvitationRepository
    {
        Task<List<TournamentInvitation>> GetAllAsync();
        Task<TournamentInvitation?> GetByIdAsync(int id);
        Task<TournamentInvitation> CreateAsync(TournamentInvitationRequestDto tournamentInvitationRequestDto);
        Task<TournamentInvitation?> UpdateAsync(int id, TournamentInvitationRequestDto tournamentInvitationRequestDto);
        Task<TournamentInvitation?> DeleteAsync(int id);
    }
}
