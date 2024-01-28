using TournXBack.src.core.Data;
using TournXBack.src.modules.Rounds.Interfaces;
using TournXBack.src.modules.Rounds.Models;
using Microsoft.EntityFrameworkCore;

namespace TournXBack.src.modules.Rounds.Repositories
{
    public class RoundRepository(TournXDB context) : IRoundRepository
    {
        private readonly TournXDB _context = context;

        public async Task<Round> CreateAsync(RoundRequestDto roundRequestDto)
        {
            var lastRound = await _context.Rounds.OrderByDescending(p => p.Id).FirstOrDefaultAsync();
            if (lastRound != null) {
                var newRound = new Round {
                    Id = lastRound.Id + 1,
                    BestOf     = roundRequestDto.BestOf,
                    NumTeams   = roundRequestDto.NumTeams,
                    Winner     = roundRequestDto.Winner,
                    Rivals     = roundRequestDto.Rivals,
                    NextRound  = roundRequestDto.NextRound,
                    Tournament = roundRequestDto.Tournament,
                    HasWinner  = roundRequestDto.HasWinner
                };
                await _context.Rounds.AddAsync(newRound);
                await _context.SaveChangesAsync();
                return newRound;
            }
            else {
                var newRound = new Round {
                    Id = 1,
                    BestOf     = roundRequestDto.BestOf,
                    NumTeams   = roundRequestDto.NumTeams,
                    Winner     = roundRequestDto.Winner,
                    Rivals     = roundRequestDto.Rivals,
                    NextRound  = roundRequestDto.NextRound,
                    Tournament = roundRequestDto.Tournament,
                    HasWinner  = roundRequestDto.HasWinner
                };
                await _context.Rounds.AddAsync(newRound);
                await _context.SaveChangesAsync();
                return newRound;
            }
        }

        public async Task<Round?> DeleteAsync(int id)
        {
            var round = await _context.Rounds.FirstOrDefaultAsync(x => x.Id == id);
            if (round == null) return null;

            _context.Rounds.Remove(round);

            await _context.SaveChangesAsync();

            return round;
        }

        public async Task<List<Round>> GetAllAsync()
        {
            return await _context.Rounds.ToListAsync();
        }

        public async Task<Round?> GetByIdAsync(int id)
        {
            return await _context.Rounds.FindAsync(id);
        }

        public async Task<Round?> UpdateAsync(int id, RoundRequestDto roundRequestDto)
        {
            var existingRound = await _context.Rounds.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRound == null) return null;

            existingRound.BestOf     = roundRequestDto.BestOf;
            existingRound.NumTeams   = roundRequestDto.NumTeams;
            existingRound.Winner     = roundRequestDto.Winner;
            existingRound.Rivals     = roundRequestDto.Rivals;
            existingRound.NextRound  = roundRequestDto.NextRound;
            existingRound.Tournament = roundRequestDto.Tournament;
            existingRound.HasWinner  = roundRequestDto.HasWinner;

            await _context.SaveChangesAsync();
            
            return existingRound;
        }
    }
}
