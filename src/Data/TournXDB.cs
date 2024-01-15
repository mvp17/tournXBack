using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TournXBack.Players.Models;
using TournXBack.Teams.Models;

namespace TournXBack.Data
{
    public class TournXDB : IdentityDbContext<Player>
    {
        public TournXDB(DbContextOptions<TournXDB> options) : base(options)
        {

        }
        
        public DbSet<Team> Teams => Set<Team>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            List<IdentityRole> roles = new()
            {
                new() {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new() {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
