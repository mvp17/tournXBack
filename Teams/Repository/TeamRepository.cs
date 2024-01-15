using Microsoft.EntityFrameworkCore;
using TournXBack.Data;
using TournXBack.Teams.Interfaces;
using TournXBack.Teams.Models;

namespace TournXBack.Teams.Repository
{
    public class TeamRepository(TournXDB context) : ITeamRepository
    {
        private readonly TournXDB _context = context;

        public async Task<Team> CreateAsync(TeamRequestDto teamDto)
        {
            var lastTeam = await _context.Teams.OrderByDescending(p => p.Id).FirstOrDefaultAsync();
            if (lastTeam != null) {
                var newTeam = new Team {
                    Id = lastTeam.Id + 1,
                    Name = teamDto.Name,
                    Level = teamDto.Level,
                    Game = teamDto.Game
                };
                await _context.Teams.AddAsync(newTeam);
                await _context.SaveChangesAsync();
                return newTeam;
            }
            else {
                var newTeam = new Team {
                    Id = 1,
                    Name = teamDto.Name,
                    Level = teamDto.Level,
                    Game = teamDto.Game
                };
                await _context.Teams.AddAsync(newTeam);
                await _context.SaveChangesAsync();
                return newTeam;
            }
        }

        public async Task<Team?> DeleteAsync(int id)
        {
            var team = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);
            if (team == null) return null;

            _context.Teams.Remove(team);

            await _context.SaveChangesAsync();

            return team;
        }

        public async Task<List<Team>> GetAllAsync()
        {
            return await _context.Teams.ToListAsync();
        }

        public async Task<Team?> GetByIdAsync(int id)
        {
            return await _context.Teams.FindAsync(id);
        }

        public async Task<Team?> UpdateAsync(int id, TeamRequestDto teamDto)
        {
            var existingTeam = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);
            if (existingTeam == null) return null;

            existingTeam.Name = teamDto.Name;
            existingTeam.Level = teamDto.Level;
            existingTeam.Game = teamDto.Game;

            await _context.SaveChangesAsync();
            
            return existingTeam;
        }
    }
}
