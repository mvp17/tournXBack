using Microsoft.EntityFrameworkCore;
using TournXBack.Data;
using TournXBack.Players.Interfaces;
using TournXBack.Players.Models;

namespace TournXBack.Players.Repository
{
    public class PlayerRepository(TournXDB context) : IPlayerRepository
    {
        private readonly TournXDB _context = context;

        public async Task<Player> CreateAsync(PlayerRequestDto playerDto)
        {
            var lastPlayer = await _context.Players.OrderByDescending(p => p.Id).FirstOrDefaultAsync();
            if (lastPlayer != null) {
                var newPlayer = new Player {
                    Id = lastPlayer.Id + 1,
                    Username = playerDto.Username,
                    Email = playerDto.Email,
                    Password = playerDto.Password
                };
                await _context.Players.AddAsync(newPlayer);
                await _context.SaveChangesAsync();
                return newPlayer;
            }
            else {
                var newPlayer = new Player {
                    Id = 1,
                    Username = playerDto.Username,
                    Email = playerDto.Email,
                    Password = playerDto.Password
                };
                await _context.Players.AddAsync(newPlayer);
                await _context.SaveChangesAsync();
                return newPlayer;
            }
        }

        public async Task<Player?> DeleteAsync(int id)
        {
            var player = await _context.Players.FirstOrDefaultAsync(x => x.Id == id);
            if (player == null) return null;

            _context.Players.Remove(player);

            await _context.SaveChangesAsync();

            return player;
        }

        public async Task<List<Player>> GetAllAsync()
        {
            return await _context.Players.ToListAsync();
        }

        public async Task<Player?> GetByIdAsync(int id)
        {
            return await _context.Players.FindAsync(id);
        }

        public async Task<Player?> UpdateAsync(int id, PlayerRequestDto playerDto)
        {
            var existingPlayer = await _context.Players.FirstOrDefaultAsync(x => x.Id == id);
            if (existingPlayer == null) return null;

            existingPlayer.Username = playerDto.Username;
            existingPlayer.Email = playerDto.Email;
            existingPlayer.Password = playerDto.Password;

            await _context.SaveChangesAsync();
            
            return existingPlayer;
        }
    }
}
