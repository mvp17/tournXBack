using Microsoft.AspNetCore.Mvc;
using TournXBack.Teams.Interfaces;
using TournXBack.Teams.Models;

namespace TournXBack.Teams.Controllers
{
    public class TeamController : ControllerBase
    {
        private readonly ITeamRepository _teamRepository;
        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var teams = await _teamRepository.GetAllAsync();
            return Ok(teams);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var team = await _teamRepository.GetByIdAsync(id);
            if (team == null) return NotFound();

            return Ok(team);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TeamRequestDto teamDto)
        {
            var newTeam = await _teamRepository.CreateAsync(teamDto);
            return Ok(newTeam);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] TeamRequestDto teamDto)
        {
            var updatedTeam = await _teamRepository.UpdateAsync(id, teamDto);
            if (updatedTeam == null) return NotFound();

            return Ok(updatedTeam);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var team = await _teamRepository.DeleteAsync(id);
            if (team == null) return NotFound();

            return NoContent();
        }
    }
}
