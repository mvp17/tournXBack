using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TournXBack.src.MatchResults.Models;
using TournXBack.src.Players.Models;
using TournXBack.src.TeamInvitations.Models;
using TournXBack.src.Teams.Models;
using TournXBack.src.TournamentInvitations.Models;
using TournXBack.src.Tournaments.Models;

namespace TournXBack.src.Data
{
    public class TournXDB : IdentityDbContext<Player>
    {
        public TournXDB(DbContextOptions<TournXDB> options) : base(options)
        {

        }
        
        public DbSet<Team> Teams => Set<Team>();
        public DbSet<Tournament> Tournaments => Set<Tournament>();
        public DbSet<MatchResult> MatchResults => Set<MatchResult>();
        public DbSet<TeamInvitation> TeamInvitations => Set<TeamInvitation>();
        public DbSet<TournamentInvitation> TournamentInvitations => Set<TournamentInvitation>();

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
