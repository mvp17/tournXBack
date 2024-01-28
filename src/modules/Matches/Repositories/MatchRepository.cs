using TournXBack.src.core.Data;
using TournXBack.src.modules.Matches.Models;
using Microsoft.EntityFrameworkCore;
using TournXBack.src.modules.Matches.Interfaces;

namespace TournXBack.src.modules.Matches.Repositories
{
    public class MatchRepository(TournXDB context) : IMatchRepository
    {
        private readonly TournXDB _context = context;

        public async Task<Match> CreateAsync(MatchRequestDto matchRequestDto)
        {
            var lastMatch = await _context.MatchResults.OrderByDescending(p => p.Id).FirstOrDefaultAsync();
            if (lastMatch != null) {
                var newMatch = new Match {
                    Id = lastMatch.Id + 1,
                    Description = matchRequestDto.Description,
                    Winner      = matchRequestDto.Winner,
                    Round       = matchRequestDto.Round
                };
                await _context.Matches.AddAsync(newMatch);
                await _context.SaveChangesAsync();
                return newMatch;
            }
            else {
                var newMatch = new Match {
                    Id = 1,
                    Description = matchRequestDto.Description,
                    Winner      = matchRequestDto.Winner,
                    Round       = matchRequestDto.Round
                };
                await _context.Matches.AddAsync(newMatch);
                await _context.SaveChangesAsync();
                return newMatch;
            }
        }

        public async Task<Match?> DeleteAsync(int id)
        {
            var match = await _context.Matches.FirstOrDefaultAsync(x => x.Id == id);
            if (match == null) return null;

            _context.Matches.Remove(match);

            await _context.SaveChangesAsync();

            return match;
        }

        public async Task<List<Match>> GetAllAsync()
        {
            return await _context.Matches.ToListAsync();
        }

        public async Task<Match?> GetByIdAsync(int id)
        {
            return await _context.Matches.FindAsync(id);
        }

        public async Task<Match?> UpdateAsync(int id, MatchRequestDto matchRequestDto)
        {
            var existingMatch = await _context.Matches.FirstOrDefaultAsync(x => x.Id == id);
            if (existingMatch == null) return null;

            existingMatch.Description = matchRequestDto.Description;
            existingMatch.Winner      = matchRequestDto.Winner;
            existingMatch.Round       = matchRequestDto.Round;

            await _context.SaveChangesAsync();
            
            return existingMatch;
        }
    }
}
