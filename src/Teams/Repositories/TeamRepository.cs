using Microsoft.EntityFrameworkCore;
using TournXBack.src.Data;
using TournXBack.src.Teams.Interfaces;
using TournXBack.src.Teams.Models;

namespace TournXBack.src.Teams.Repositories
{
    public class TeamRepository(TournXDB context) : ITeamRepository
    {
        private readonly TournXDB _context = context;

        public async Task<Team> CreateAsync(TeamRequestDto teamRequestDto)
        {
            var lastTeam = await _context.Teams.OrderByDescending(p => p.Id).FirstOrDefaultAsync();
            if (lastTeam != null) {
                var newTeam = new Team {
                    Id = lastTeam.Id + 1,
                    Name = teamRequestDto.Name,
                    Level = teamRequestDto.Level,
                    Game = teamRequestDto.Game
                };
                await _context.Teams.AddAsync(newTeam);
                await _context.SaveChangesAsync();
                return newTeam;
            }
            else {
                var newTeam = new Team {
                    Id = 1,
                    Name = teamRequestDto.Name,
                    Level = teamRequestDto.Level,
                    Game = teamRequestDto.Game
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

        public async Task<Team?> UpdateAsync(int id, TeamRequestDto teamRequestDto)
        {
            var existingTeam = await _context.Teams.FirstOrDefaultAsync(x => x.Id == id);
            if (existingTeam == null) return null;

            existingTeam.Name = teamRequestDto.Name;
            existingTeam.Level = teamRequestDto.Level;
            existingTeam.Game = teamRequestDto.Game;

            await _context.SaveChangesAsync();
            
            return existingTeam;
        }
    }
}
