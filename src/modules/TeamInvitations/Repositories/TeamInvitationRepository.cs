using Microsoft.EntityFrameworkCore;
using TournXBack.src.core.Data;
using TournXBack.src.modules.TeamInvitations.Interfaces;
using TournXBack.src.modules.TeamInvitations.Models;

namespace TournXBack.src.modules.TeamInvitations.Repositories
{
    public class TeamInvitationRepository(TournXDB context) : ITeamInvitationRepository
    {
        private readonly TournXDB _context = context;

        public async Task<TeamInvitation> CreateAsync(TeamInvitationRequestDto teamInvitationRequestDto)
        {
            var lastTeamInvitation = await _context.TeamInvitations.OrderByDescending(p => p.Id).FirstOrDefaultAsync();
            if (lastTeamInvitation != null) {
                var newTeamInvitation = new TeamInvitation {
                    Id       = lastTeamInvitation.Id + 1,
                    PlayerId = teamInvitationRequestDto.PlayerId,
                    TeamId   = teamInvitationRequestDto.TeamId,
                    Message  = teamInvitationRequestDto.Message,
                    Accepted = teamInvitationRequestDto.Accepted
                };
                await _context.TeamInvitations.AddAsync(newTeamInvitation);
                await _context.SaveChangesAsync();
                return newTeamInvitation;
            }
            else {
                var newTeamInvitation = new TeamInvitation {
                    Id       = 1,
                    PlayerId = teamInvitationRequestDto.PlayerId,
                    TeamId   = teamInvitationRequestDto.TeamId,
                    Message  = teamInvitationRequestDto.Message,
                    Accepted = teamInvitationRequestDto.Accepted
                };
                await _context.TeamInvitations.AddAsync(newTeamInvitation);
                await _context.SaveChangesAsync();
                return newTeamInvitation;
            }
        }

        public async Task<TeamInvitation?> DeleteAsync(int id)
        {
            var teamInvitation = await _context.TeamInvitations.FirstOrDefaultAsync(x => x.Id == id);
            if (teamInvitation == null) return null;

            _context.TeamInvitations.Remove(teamInvitation);

            await _context.SaveChangesAsync();

            return teamInvitation;
        }

        public async Task<List<TeamInvitation>> GetAllAsync()
        {
            return await _context.TeamInvitations.ToListAsync();
        }

        public async Task<TeamInvitation?> GetByIdAsync(int id)
        {
            return await _context.TeamInvitations.FindAsync(id);
        }

        public async Task<TeamInvitation?> UpdateAsync(int id, TeamInvitationRequestDto teamInvitationRequestDto)
        {
            var existingTeamInvitation = await _context.TeamInvitations.FirstOrDefaultAsync(x => x.Id == id);
            if (existingTeamInvitation == null) return null;

            existingTeamInvitation.PlayerId = teamInvitationRequestDto.PlayerId;
            existingTeamInvitation.TeamId   = teamInvitationRequestDto.TeamId;
            existingTeamInvitation.Message  = teamInvitationRequestDto.Message;
            existingTeamInvitation.Accepted = teamInvitationRequestDto.Accepted;

            await _context.SaveChangesAsync();
            
            return existingTeamInvitation;
        }
    }
}
