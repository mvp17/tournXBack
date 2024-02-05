using Microsoft.EntityFrameworkCore;
using TournXBack.src.core.Data;
using TournXBack.src.modules.Tournaments.Interfaces;
using TournXBack.src.modules.Tournaments.Models;

namespace TournXBack.src.modules.Tournaments.Repositories
{
    public class TournamentRepository(TournXDB context) : ITournamentRepository
    {
        private readonly TournXDB _context = context;

        public async Task<Tournament> CreateAsync(TournamentRequestDto tournamentRequestDto)
        {
            var lastTournament = await _context.Tournaments.OrderByDescending(p => p.Id).FirstOrDefaultAsync();
            if (lastTournament != null) {
                var newTournament = new Tournament {
                    Id              = lastTournament.Id + 1,
                    Name            = tournamentRequestDto.Name,
                    Level           = tournamentRequestDto.Level,
                    Game            = tournamentRequestDto.Game,
                    Type            = tournamentRequestDto.Type,
                    Description     = tournamentRequestDto.Description,
                    MinParticipants = tournamentRequestDto.MinParticipants,
                    MaxParticipants = tournamentRequestDto.MaxParticipants,
                    MinTeamPlayers  = tournamentRequestDto.MinTeamPlayers,
                    MaxTeamPlayers  = tournamentRequestDto.MaxTeamPlayers,
                    Participants    = tournamentRequestDto.Participants,
                    TeamId          = tournamentRequestDto.TeamId,
                    BestOf          = tournamentRequestDto.BestOf,
                    State           = tournamentRequestDto.State
                };
                await _context.Tournaments.AddAsync(newTournament);
                await _context.SaveChangesAsync();
                return newTournament;
            }
            else {
                var newTournament = new Tournament {
                    Id    = 1,
                    Name  = tournamentRequestDto.Name,
                    Level = tournamentRequestDto.Level,
                    Game  = tournamentRequestDto.Game,
                    Type  = tournamentRequestDto.Type,
                    Description     = tournamentRequestDto.Description,
                    MinParticipants = tournamentRequestDto.MinParticipants,
                    MaxParticipants = tournamentRequestDto.MaxParticipants,
                    MinTeamPlayers  = tournamentRequestDto.MinTeamPlayers,
                    MaxTeamPlayers  = tournamentRequestDto.MaxTeamPlayers,
                    Participants    = tournamentRequestDto.Participants,
                    TeamId          = tournamentRequestDto.TeamId,
                    BestOf          = tournamentRequestDto.BestOf,
                    State           = tournamentRequestDto.State
                };
                await _context.Tournaments.AddAsync(newTournament);
                await _context.SaveChangesAsync();
                return newTournament;
            }
        }

        public async Task<Tournament?> DeleteAsync(int id)
        {
            var tournament = await _context.Tournaments.FirstOrDefaultAsync(x => x.Id == id);
            if (tournament == null) return null;

            _context.Tournaments.Remove(tournament);

            await _context.SaveChangesAsync();

            return tournament;
        }

        public async Task<List<Tournament>> GetAllAsync()
        {
            return await _context.Tournaments.ToListAsync();
        }

        public async Task<Tournament?> GetByIdAsync(int id)
        {
            return await _context.Tournaments.FindAsync(id);
        }

        public async Task<Tournament?> UpdateAsync(int id,TournamentRequestDto tournamentRequestDto)
        {
            var existingTournament = await _context.Tournaments.FirstOrDefaultAsync(x => x.Id == id);
            if (existingTournament == null) return null;

            existingTournament.Name            = tournamentRequestDto.Name;
            existingTournament.Level           = tournamentRequestDto.Level;
            existingTournament.Game            = tournamentRequestDto.Game;
            existingTournament.Type            = tournamentRequestDto.Type;
            existingTournament.Description     = tournamentRequestDto.Description;
            existingTournament.MinParticipants = tournamentRequestDto.MinParticipants;
            existingTournament.MaxParticipants = tournamentRequestDto.MaxParticipants;
            existingTournament.MinTeamPlayers  = tournamentRequestDto.MinTeamPlayers;
            existingTournament.MaxTeamPlayers  = tournamentRequestDto.MaxTeamPlayers;
            existingTournament.Participants    = tournamentRequestDto.Participants;
            existingTournament.TeamId          = tournamentRequestDto.TeamId;
            existingTournament.BestOf          = tournamentRequestDto.BestOf;
            existingTournament.State           = tournamentRequestDto.State;

            await _context.SaveChangesAsync();
            
            return existingTournament;
        }
    }
}
