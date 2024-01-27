using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TournXBack.src.TournamentInvitations.Interfaces;
using TournXBack.src.TournamentInvitations.Models;

namespace TournXBack.src.TournamentInvitations.Controllers
{
    [Route("api/tournamentInvitation")]
    [ApiController]
    public class TournamentInvitationController : ControllerBase
    {
        private readonly ITournamentInvitationRepository _tournamentInvitationRepository;
        public TournamentInvitationController(ITournamentInvitationRepository tournamentInvitationRepository)
        {
            _tournamentInvitationRepository = tournamentInvitationRepository;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest();
            var tournamentInvitations = await _tournamentInvitationRepository.GetAllAsync();
            return Ok(tournamentInvitations);
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var tournamentInvitation = await _tournamentInvitationRepository.GetByIdAsync(id);
            if (tournamentInvitation == null) return NotFound();
            return Ok(tournamentInvitation);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] TournamentInvitationRequestDto tournamentInvitationRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var newTournamentInvitation = await _tournamentInvitationRepository.CreateAsync(tournamentInvitationRequestDto);
            return Ok(newTournamentInvitation);
        }

        [HttpPut]
        [Authorize]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TournamentInvitationRequestDto tournamentInvitationRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var updatedTournamentInvitation = await _tournamentInvitationRepository.UpdateAsync(id, tournamentInvitationRequestDto);
            if (updatedTournamentInvitation == null) return NotFound();

            return Ok(updatedTournamentInvitation);
        }

        [HttpDelete]
        [Authorize]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            var tournamentInvitation = await _tournamentInvitationRepository.DeleteAsync(id);
            if (tournamentInvitation == null) return NotFound();

            return NoContent();
        }
    }
}
