using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TournXBack.src.modules.Teams.Interfaces;
using TournXBack.src.modules.Teams.Models;

namespace TournXBack.src.modules.Teams.Controllers
{
    [Route("api/team")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository _teamRepository;
        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet]
        [Authorize/*(Roles = "Player")*/]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest();
            var teams = await _teamRepository.GetAllAsync();
            return Ok(teams);
        }

        [HttpGet("{id:int}")]
        [Authorize/*(Roles = "Player")*/]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var team = await _teamRepository.GetByIdAsync(id);
            if (team == null) return NotFound();
            return Ok(team);
        }

        [HttpPost]
        [Authorize/*(Roles = "Player")*/]
        public async Task<IActionResult> Create([FromBody] TeamRequestDto teamDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var newTeam = await _teamRepository.CreateAsync(teamDto);
            return Ok(newTeam);
        }

        [HttpPut]
        [Authorize/*(Roles = "Player")*/]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TeamRequestDto teamDto)
        {
            if (!ModelState.IsValid) return BadRequest();
            var updatedTeam = await _teamRepository.UpdateAsync(id, teamDto);
            if (updatedTeam == null) return NotFound();

            return Ok(updatedTeam);
        }

        [HttpDelete]
        [Authorize/*(Roles = "Player")*/]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest();
            var team = await _teamRepository.DeleteAsync(id);
            if (team == null) return NotFound();
            
            return NoContent();
        }
    }
}
