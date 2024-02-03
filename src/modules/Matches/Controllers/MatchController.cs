using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TournXBack.src.modules.Matches.Interfaces;
using TournXBack.src.modules.Matches.Models;

namespace TournXBack.src.modules.Matches.Controllers
{
    public class MatchController : ControllerBase
    {
        private readonly IMatchRepository _matchRepository;
        public MatchController(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Tournament Master")]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest();
            var matches = await _matchRepository.GetAllAsync();
            return Ok(matches);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Tournament Master")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var match = await _matchRepository.GetByIdAsync(id);
            if (match == null) return NotFound();
            return Ok(match);
        }

        [HttpPost]
        [Authorize(Roles = "Tournament Master")]
        public async Task<IActionResult> Create([FromBody] MatchRequestDto matchRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var newMatch = await _matchRepository.CreateAsync(matchRequestDto);
            return Ok(newMatch);
        }

        [HttpPut]
        [Authorize(Roles = "Tournament Master")]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] MatchRequestDto matchRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var updatedMatch = await _matchRepository.UpdateAsync(id, matchRequestDto);
            if (updatedMatch == null) return NotFound();

            return Ok(updatedMatch);
        }

        [HttpDelete]
        [Authorize(Roles = "Tournament Master")]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            var match = await _matchRepository.DeleteAsync(id);
            if (match == null) return NotFound();

            return NoContent();
        }
    }
}
