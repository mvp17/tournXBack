using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TournXBack.src.core.Data;
using TournXBack.src.modules.Players.Models;
using TournXBack.src.modules.Teams.Interfaces;
using TournXBack.src.modules.Teams.Repositories;
using TournXBack.src.modules.Tournaments.Interfaces;
using TournXBack.src.modules.Tournaments.Repositories;
using TournXBack.src.modules.MatchResults.Interfaces;
using TournXBack.src.modules.MatchResults.Repositories;
using TournXBack.src.modules.TeamInvitations.Interfaces;
using TournXBack.src.modules.TeamInvitations.Repositories;
using TournXBack.src.modules.TournamentInvitations.Interfaces;
using TournXBack.src.modules.TournamentInvitations.Repositories;
using TournXBack.src.core.Services;
using TournXBack.src.modules.Matches.Repositories;
using TournXBack.src.modules.Matches.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("PostgreSQLConnection");
builder.Services.AddDbContext<TournXDB>(options =>
    options.UseNpgsql(connectionString)
);

builder.Services.AddIdentity<Player, IdentityRole>(options => {
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
}).AddEntityFrameworkStores<TournXDB>();

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = 
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme = 
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidIssuer = builder.Configuration["JWT:Issuer"] ?? throw new ArgumentNullException("JWT:Issuer"),
    ValidateAudience = true,
    ValidAudience = builder.Configuration["JWT:Audience"] ?? throw new ArgumentNullException("JWT:Audience"),
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(
        System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"] ?? throw new ArgumentNullException("JWT:SigningKey"))
    )
};
});

builder.Services.AddScoped<ITeamRepository, TeamRepository>();
builder.Services.AddScoped<ITournamentRepository, TournamentRepository>();
builder.Services.AddScoped<IMatchResultRepository, MatchResultRepository>();
builder.Services.AddScoped<ITeamInvitationRepository, TeamInvitationRepository>();
builder.Services.AddScoped<ITournamentInvitationRepository, TournamentInvitationRepository>();
builder.Services.AddScoped<IMatchRepository, MatchRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
