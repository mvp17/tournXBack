using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TournXBack.src.modules.Matches.Models;
using TournXBack.src.modules.MatchResults.Models;
using TournXBack.src.modules.Players.Models;
using TournXBack.src.modules.Rounds.Models;
using TournXBack.src.modules.TeamInvitations.Models;
using TournXBack.src.modules.Teams.Models;
using TournXBack.src.modules.TournamentInvitations.Models;
using TournXBack.src.modules.Tournaments.Models;

namespace TournXBack.src.core.Data
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
        public DbSet<Match> Matches => Set<Match>();
        public DbSet<Round> Rounds => Set<Round>();

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
                    Name = "Player",
                    NormalizedName = "PLAYER"
                },
                new() {
                    Name = "Tournament Master",
                    NormalizedName = "TOURNAMENT MASTER"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
