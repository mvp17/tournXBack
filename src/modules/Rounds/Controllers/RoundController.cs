using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TournXBack.src.modules.Rounds.Interfaces;
using TournXBack.src.modules.Rounds.Models;

namespace TournXBack.src.modules.Rounds.Controllers
{
    public class RoundController : ControllerBase
    {
        private readonly IRoundRepository _roundRepository;
        public RoundController(IRoundRepository roundRepository)
        {
            _roundRepository = roundRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Master")]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest();
            var rounds = await _roundRepository.GetAllAsync();
            return Ok(rounds);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Master")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var round = await _roundRepository.GetByIdAsync(id);
            if (round == null) return NotFound();
            return Ok(round);
        }

        [HttpPost]
        [Authorize(Roles = "Master")]
        public async Task<IActionResult> Create([FromBody] RoundRequestDto roundRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var newRound = await _roundRepository.CreateAsync(roundRequestDto);
            return Ok(newRound);
        }

        [HttpPut]
        [Authorize(Roles = "Master")]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] RoundRequestDto roundRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var updatedRound = await _roundRepository.UpdateAsync(id, roundRequestDto);
            if (updatedRound == null) return NotFound();

            return Ok(updatedRound);
        }

        [HttpDelete]
        [Authorize(Roles = "Master")]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            var round = await _roundRepository.DeleteAsync(id);
            if (round == null) return NotFound();

            return NoContent();
        }
    }
}
