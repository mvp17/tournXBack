using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TournXBack.src.modules.TeamInvitations.Interfaces;
using TournXBack.src.modules.TeamInvitations.Models;

namespace TournXBack.src.modules.TeamInvitations.Controllers
{
    [Route("api/teamInvitation")]
    [ApiController]
    public class TeamInvitationController : ControllerBase
    {
        private readonly ITeamInvitationRepository _teamInvitationRepository;
        public TeamInvitationController(ITeamInvitationRepository teamInvitationRepository)
        {
            _teamInvitationRepository = teamInvitationRepository;
        }

        [HttpGet]
        [Authorize/*(Roles = "Player")*/]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest();
            var teamInvitations = await _teamInvitationRepository.GetAllAsync();
            return Ok(teamInvitations);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Player")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var teamInvitation = await _teamInvitationRepository.GetByIdAsync(id);
            if (teamInvitation == null) return NotFound();
            return Ok(teamInvitation);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] TeamInvitationRequestDto teamInvitationRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var newTeamInvitation = await _teamInvitationRepository.CreateAsync(teamInvitationRequestDto);
            return Ok(newTeamInvitation);
        }

        [HttpPut]
        [Authorize/*(Roles = "Player")*/]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TeamInvitationRequestDto teamInvitationRequestDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var updatedTeamInvitation = await _teamInvitationRepository.UpdateAsync(id, teamInvitationRequestDto);
            if (updatedTeamInvitation == null) return NotFound();

            return Ok(updatedTeamInvitation);
        }

        [HttpDelete]
        [Authorize/*(Roles = "Player")*/]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            var teamInvitation = await _teamInvitationRepository.DeleteAsync(id);
            if (teamInvitation == null) return NotFound();

            return NoContent();
        }
    }
}
