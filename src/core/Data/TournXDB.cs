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
using TournXBack.src.modules.TournamentMasters.Models;
using TournXBack.src.modules.Tournaments.Models;

namespace TournXBack.src.core.Data
{
    public class TournXDB : IdentityDbContext<IdentityUser>
    {
        public TournXDB(DbContextOptions<TournXDB> options) : base(options) { }
        
        public DbSet<Team> Teams => Set<Team>();
        public DbSet<Tournament> Tournaments => Set<Tournament>();
        public DbSet<MatchResult> MatchResults => Set<MatchResult>();
        public DbSet<TeamInvitation> TeamInvitations => Set<TeamInvitation>();
        public DbSet<TournamentInvitation> TournamentInvitations => Set<TournamentInvitation>();
        public DbSet<Match> Matches => Set<Match>();
        public DbSet<Round> Rounds => Set<Round>();
        public DbSet<Player> Players => Set<Player>();
        public DbSet<Master> Masters => Set<Master>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); 

            List<IdentityRole> roles =
            [
                new() {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new() {
                    Name = "Master",
                    NormalizedName = "MASTER"
                },
                new() {
                    Name = "Player",
                    NormalizedName = "PLAYER"
                }
            ];
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
