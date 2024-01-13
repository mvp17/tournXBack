using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournXBack.Data;
using TournXBack.Players.Models;

namespace TournXBack.Players.Controllers
{
    [Route("api/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly TournXDB _context;
        public PlayerController(TournXDB context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var players = await _context.Players.ToListAsync();
            return Ok(players);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null) return NotFound();

            return Ok(player);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PlayerRequestDto playerDto)
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
                return Ok(newPlayer);
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
                return Ok(newPlayer);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PlayerRequestDto playerDto)
        {
            var player = await _context.Players.FirstOrDefaultAsync(x => x.Id == id);
            if (player == null) return NotFound();

            player.Username = playerDto.Username;
            player.Email = playerDto.Email;
            player.Password = playerDto.Password;

            await _context.SaveChangesAsync();

            return Ok(player);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var player = _context.Players.FirstOrDefault(x => x.Id == id);
            if (player == null) return NotFound();

            _context.Players.Remove(player);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
