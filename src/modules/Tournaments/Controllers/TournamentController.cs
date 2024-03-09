using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TournXBack.src.modules.Tournaments.Interfaces;
using TournXBack.src.modules.Tournaments.Models;

namespace TournXBack.src.Tournaments.Controllers
{
    [Route("api/tournament")]
    [ApiController]
    public class TournamentController : ControllerBase
    {
        private readonly ITournamentRepository _tournamentRepository;
        public TournamentController(ITournamentRepository tournamentRepository)
        {
            _tournamentRepository = tournamentRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Master")]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest();
            var tournaments = await _tournamentRepository.GetAllAsync();
            return Ok(tournaments);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Master")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var tournament = await _tournamentRepository.GetByIdAsync(id);
            if (tournament == null) return NotFound();
            return Ok(tournament);
        }

        [HttpPost]
        [Authorize(Roles = "Master")]
        public async Task<IActionResult> Create([FromBody] TournamentRequestDto tournamentRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var newTournament = await _tournamentRepository.CreateAsync(tournamentRequestDto);
            return Ok(newTournament);
        }

        [HttpPut]
        [Authorize(Roles = "Tournament Master")]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TournamentRequestDto tournamentRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var updatedTournament = await _tournamentRepository.UpdateAsync(id, tournamentRequestDto);
            if (updatedTournament == null) return NotFound();

            return Ok(updatedTournament);
        }

        [HttpDelete]
        [Authorize(Roles = "Master")]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            var tournament = await _tournamentRepository.DeleteAsync(id);
            if (tournament == null) return NotFound();

            return NoContent();
        }
    }
}
