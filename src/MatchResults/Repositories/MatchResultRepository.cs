using Microsoft.EntityFrameworkCore;
using TournXBack.src.Data;
using TournXBack.src.MatchResults.Interfaces;
using TournXBack.src.MatchResults.Models;

namespace TournXBack.src.MatchResults.Repositories
{
    public class MatchResultRepository(TournXDB context) : IMatchResultRepository
    {
        private readonly TournXDB _context = context;

        public async Task<MatchResult> CreateAsync(MatchResultRequestDto matchResultRequestDto)
        {
            var lastMatchResult = await _context.MatchResults.OrderByDescending(p => p.Id).FirstOrDefaultAsync();
            if (lastMatchResult != null) {
                var newMatchResult = new MatchResult {
                    Id    = lastMatchResult.Id + 1,
                    Match  = matchResultRequestDto.Match,
                    WinnerTeam = matchResultRequestDto.WinnerTeam,
                    Result  = matchResultRequestDto.Result
                };
                await _context.MatchResults.AddAsync(newMatchResult);
                await _context.SaveChangesAsync();
                return newMatchResult;
            }
            else {
                var newMatchResult = new MatchResult {
                    Id    = 1,
                    Match  = matchResultRequestDto.Match,
                    WinnerTeam = matchResultRequestDto.WinnerTeam,
                    Result  = matchResultRequestDto.Result
                };
                await _context.MatchResults.AddAsync(newMatchResult);
                await _context.SaveChangesAsync();
                return newMatchResult;
            }
        }

        public async Task<MatchResult?> DeleteAsync(int id)
        {
            var matchResult = await _context.MatchResults.FirstOrDefaultAsync(x => x.Id == id);
            if (matchResult == null) return null;

            _context.MatchResults.Remove(matchResult);

            await _context.SaveChangesAsync();

            return matchResult;
        }

        public async Task<List<MatchResult>> GetAllAsync()
        {
            return await _context.MatchResults.ToListAsync();
        }

        public async Task<MatchResult?> GetByIdAsync(int id)
        {
            return await _context.MatchResults.FindAsync(id);
        }

        public async Task<MatchResult?> UpdateAsync(int id, MatchResultRequestDto matchResultRequestDto)
        {
            var existingMatchResult = await _context.MatchResults.FirstOrDefaultAsync(x => x.Id == id);
            if (existingMatchResult == null) return null;

            existingMatchResult.Match  = matchResultRequestDto.Match;
            existingMatchResult.WinnerTeam = matchResultRequestDto.WinnerTeam;
            existingMatchResult.Result  = matchResultRequestDto.Result;

            await _context.SaveChangesAsync();
            
            return existingMatchResult;
        }
    }
}
