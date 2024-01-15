using Microsoft.AspNetCore.Mvc;
using TournXBack.Players.Interfaces;
using TournXBack.Players.Models;

namespace TournXBack.Players.Controllers
{
    [Route("api/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerRepository _playerRepository;
        public PlayerController(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var players = await _playerRepository.GetAllAsync();
            return Ok(players);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var player = await _playerRepository.GetByIdAsync(id);
            if (player == null) return NotFound();

            return Ok(player);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PlayerRequestDto playerDto)
        {
            var newPlayer = await _playerRepository.CreateAsync(playerDto);
            return Ok(newPlayer);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] PlayerRequestDto playerDto)
        {
            var updatedPlayer = await _playerRepository.UpdateAsync(id, playerDto);
            if (updatedPlayer == null) return NotFound();

            return Ok(updatedPlayer);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var player = await _playerRepository.DeleteAsync(id);
            if (player == null) return NotFound();

            return NoContent();
        }
    }
}
