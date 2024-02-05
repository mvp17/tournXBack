using Microsoft.EntityFrameworkCore;
using TournXBack.src.core.Data;
using TournXBack.src.modules.TournamentInvitations.Interfaces;
using TournXBack.src.modules.TournamentInvitations.Models;

namespace TournXBack.src.modules.TournamentInvitations.Repositories
{
    public class TournamentInvitationRepository(TournXDB context) : ITournamentInvitationRepository
    {
        private readonly TournXDB _context = context;

        public async Task<TournamentInvitation> CreateAsync(TournamentInvitationRequestDto tournamentInvitationRequestDto)
        {
            var lastTournamentInvitation = await _context.TournamentInvitations.OrderByDescending(p => p.Id).FirstOrDefaultAsync();
            if (lastTournamentInvitation != null) {
                var newTournamentInvitation = new TournamentInvitation {
                    Id                     = lastTournamentInvitation.Id + 1,
                    InvitesTo_tournamentId = tournamentInvitationRequestDto.InvitesTo_tournamentId,
                    TeamId                 = tournamentInvitationRequestDto.TeamId,
                    Message                = tournamentInvitationRequestDto.Message,
                    Invites_playerId       = tournamentInvitationRequestDto.Invites_playerId
                };
                await _context.TournamentInvitations.AddAsync(newTournamentInvitation);
                await _context.SaveChangesAsync();
                return newTournamentInvitation;
            }
            else {
                var newTournamentInvitation = new TournamentInvitation {
                    Id                     = 1,
                    InvitesTo_tournamentId = tournamentInvitationRequestDto.InvitesTo_tournamentId,
                    TeamId                 = tournamentInvitationRequestDto.TeamId,
                    Message                = tournamentInvitationRequestDto.Message,
                    Invites_playerId       = tournamentInvitationRequestDto.Invites_playerId
                };
                await _context.TournamentInvitations.AddAsync(newTournamentInvitation);
                await _context.SaveChangesAsync();
                return newTournamentInvitation;
            }
        }

        public async Task<TournamentInvitation?> DeleteAsync(int id)
        {
            var tournamentInvitation = await _context.TournamentInvitations.FirstOrDefaultAsync(x => x.Id == id);
            if (tournamentInvitation == null) return null;

            _context.TournamentInvitations.Remove(tournamentInvitation);

            await _context.SaveChangesAsync();

            return tournamentInvitation;
        }

        public async Task<List<TournamentInvitation>> GetAllAsync()
        {
            return await _context.TournamentInvitations.ToListAsync();
        }

        public async Task<TournamentInvitation?> GetByIdAsync(int id)
        {
            return await _context.TournamentInvitations.FindAsync(id);
        }

        public async Task<TournamentInvitation?> UpdateAsync(int id, TournamentInvitationRequestDto tournamentInvitationRequestDto)
        {
            var existingTournamentInvitation = await _context.TournamentInvitations.FirstOrDefaultAsync(x => x.Id == id);
            if (existingTournamentInvitation == null) return null;

            existingTournamentInvitation.InvitesTo_tournamentId = tournamentInvitationRequestDto.InvitesTo_tournamentId;
            existingTournamentInvitation.TeamId                 = tournamentInvitationRequestDto.TeamId;
            existingTournamentInvitation.Message                = tournamentInvitationRequestDto.Message;
            existingTournamentInvitation.Invites_playerId       = tournamentInvitationRequestDto.Invites_playerId;

            await _context.SaveChangesAsync();
            
            return existingTournamentInvitation;
        }
    }
}
