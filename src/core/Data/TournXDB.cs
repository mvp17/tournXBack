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
        public DbSet<RoundTeam> RoundTeams { get; set; }
        public DbSet<TeamPlayer> TeamPlayers { get; set; }
        public DbSet<TournamentTeam> TournamentTeams { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<RoundTeam>(x => x.HasKey(p => new { p.RoundId, p.TeamId }));
            builder.Entity<RoundTeam>()
                .HasOne(u => u.Round)
                .WithMany(u => u.Rivals)
                .HasForeignKey(p => p.RoundId);
            builder.Entity<RoundTeam>()
                .HasOne(u => u.Team)
                .WithMany(u => u.RoundTeams)
                .HasForeignKey(p => p.TeamId);

            builder.Entity<TeamPlayer>(x => x.HasKey(p => new { p.TeamId, p.PlayerId }));
            builder.Entity<TeamPlayer>()
                .HasOne(u => u.Team)
                .WithMany(u => u.Players)
                .HasForeignKey(p => p.TeamId);
            builder.Entity<TeamPlayer>()
                .HasOne(u => u.Player)
                .WithMany(u => u.TeamPlayers)
                .HasForeignKey(p => p.PlayerId);
            
            builder.Entity<TournamentTeam>(x => x.HasKey(p => new { p.TournamentId, p.TeamId }));
            builder.Entity<TournamentTeam>()
                .HasOne(u => u.Tournament)
                .WithMany(u => u.Participants)
                .HasForeignKey(p => p.TournamentId);
            builder.Entity<TournamentTeam>()
                .HasOne(u => u.Team)
                .WithMany(u => u.TournamentTeams)
                .HasForeignKey(p => p.TeamId);

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
