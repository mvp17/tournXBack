using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TournXBack.src.MatchResults.Interfaces;
using TournXBack.src.MatchResults.Models;

namespace TournXBack.src.MatchResults.Controllers
{
    [Route("api/matchResult")]
    [ApiController]
    public class MatchResultController : ControllerBase
    {
        private readonly IMatchResultRepository _matchResultRepository;
        public MatchResultController(IMatchResultRepository matchResultRepository)
        {
            _matchResultRepository = matchResultRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest();
            var matchResults = await _matchResultRepository.GetAllAsync();
            return Ok(matchResults);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var matchResult = await _matchResultRepository.GetByIdAsync(id);
            if (matchResult == null) return NotFound();
            return Ok(matchResult);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] MatchResultRequestDto matchResultRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var newMatchResult = await _matchResultRepository.CreateAsync(matchResultRequestDto);
            return Ok(newMatchResult);
        }

        [HttpPut]
        [Authorize]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] MatchResultRequestDto matchResultRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var updatedMatchResult = await _matchResultRepository.UpdateAsync(id, matchResultRequestDto);
            if (updatedMatchResult == null) return NotFound();

            return Ok(updatedMatchResult);
        }

        [HttpDelete]
        [Authorize]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            var matchResult = await _matchResultRepository.DeleteAsync(id);
            if (matchResult == null) return NotFound();

            return NoContent();
        }
    }
}
