using Microsoft.EntityFrameworkCore;
using TournXBack.Players.Models;

namespace TournXBack.Data
{
    public class TournXDB : DbContext
    {
        public TournXDB(DbContextOptions<TournXDB> options) : base(options)
        {

        }
        public DbSet<Player> Players => Set<Player>();
    }
}
