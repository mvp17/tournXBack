using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournXBack.Players.Models;
using TournXBack.src.Players.Interfaces;
using TournXBack.src.Players.Models;

namespace TournXBack.src.Players.Controllers
{
    [Route("api/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly UserManager<Player> _userManager;
        private readonly SignInManager<Player> _signinManager;
        private readonly ITokenService _tokenService;

        public PlayerController(UserManager<Player> userManager, 
                                ITokenService tokenService, 
                                SignInManager<Player> signInManager)
        {
            _userManager = userManager;
            _signinManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] PlayerRequestDto playerRequestDto)
        {
            try 
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var player = new Player
                {
                    UserName = playerRequestDto.Username,
                    Email = playerRequestDto.Email
                };

                var createdUser = await _userManager.CreateAsync(player, playerRequestDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(player, "User");
                    
                    if (roleResult.Succeeded) 
                        return Ok( new NewUserDto
                            {
                                UserName = player.UserName,
                                Email = player.Email,
                                Token = _tokenService.CreateToken(player)
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

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

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
