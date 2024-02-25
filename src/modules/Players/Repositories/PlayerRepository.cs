using Microsoft.EntityFrameworkCore;
using TournXBack.src.core.Data;
using TournXBack.src.modules.Players.interfaces;
using TournXBack.src.modules.Players.Models;

namespace TournXBack.src.modules.Players.Repositories
{
    public class PlayerRepository(TournXDB context) : IPlayerRepository
    {
        private readonly TournXDB _context = context;

        public async Task<List<Player>> GetAllAsync()
        {
            return await _context.Players.ToListAsync();
        }
    }
}