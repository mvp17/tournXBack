using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournXBack.src.core.Models;
using TournXBack.src.core.Services;
using TournXBack.src.modules.TournamentMasters.Models;

namespace TournXBack.src.modules.TournamentMasters.Controllers
{
    [Route("api/tournamentMaster")]
    [ApiController]
    public class TournamentMasterController : ControllerBase
    {
        private readonly UserManager<TournamentMaster> _userManager;
        private readonly SignInManager<TournamentMaster> _signinManager;
        private readonly ITokenService _tokenService;

        public TournamentMasterController(UserManager<TournamentMaster> userManager, 
                                ITokenService tokenService, 
                                SignInManager<TournamentMaster> signInManager)
        {
            _userManager = userManager;
            _signinManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRequestDto tournamentMasterRequestDto)
        {
            try 
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var tournamentMaster = new TournamentMaster
                {
                    UserName = tournamentMasterRequestDto.Username,
                    Email = tournamentMasterRequestDto.Email
                };

                if  (tournamentMasterRequestDto.Password == null) return BadRequest("Password cannot be null");
                
                var createdUser = await _userManager.CreateAsync(tournamentMaster, tournamentMasterRequestDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(tournamentMaster, "Tournament Master");
                    
                    if (roleResult.Succeeded) 
                        return Ok( new NewUserDto
                            {
                                UserName = tournamentMaster.UserName,
                                Email = tournamentMaster.Email,
                                Token = _tokenService.CreateToken(tournamentMaster)
                            });
                    else return StatusCode(500, roleResult.Errors);
                }
                else return StatusCode(500, createdUser.Errors);
            } catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (loginDto.Username == null || loginDto.Password == null)
                return BadRequest("Username or password cannot be null");

            var user = await _userManager.Users.FirstOrDefaultAsync(first => first.UserName == loginDto.Username.ToLower());

            if (user == null) return Unauthorized("Invalid username!");

            var result = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded) return Unauthorized("Username not found and/or password incorrect");

            return Ok(
                new NewUserDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user)
                }
            );
        }
    }
}
