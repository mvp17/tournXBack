using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TournXBack.src.core.Models;
using TournXBack.src.core.Services;
using TournXBack.src.modules.Players.interfaces;
using TournXBack.src.modules.Players.Models;

namespace TournXBack.src.modules.Players.Controllers
{
    [Route("api/player")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly ITokenService _tokenService;
        private readonly IPlayerRepository _playerRepository;

        public PlayerController(UserManager<IdentityUser> userManager, 
                                ITokenService tokenService, 
                                SignInManager<IdentityUser> signInManager,
                                IPlayerRepository playerRepository)
        {
            _userManager = userManager;
            _signinManager = signInManager;
            _tokenService = tokenService;
            _playerRepository = playerRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Player, Master")]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest();
            var players = await _playerRepository.GetAllAsync();
            List<PlayerDto> formattedPlayers = [];
            foreach (Player player in players)
            {
                formattedPlayers.Add(new PlayerDto
                {
                    Id = player.Id,
                    Username = player.UserName
                });
            }
            return Ok(formattedPlayers);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRequestDto playerRequestDto)
        {
            try 
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                var player = new Player
                {
                    UserName = playerRequestDto.Username,
                    Email = playerRequestDto.Email
                };

                if  (playerRequestDto.Password == null) return BadRequest("Password cannot be null");
                
                var createdUser = await _userManager.CreateAsync(player, playerRequestDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(player, "Player");
                    
                    if (roleResult.Succeeded) 
                        return Ok( new NewUserDto
                            {
                                Username = player.UserName,
                                Email = player.Email,
                                Token = _tokenService.CreateToken(player, ["Player"])
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
                    Username = user.UserName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user, ["Player"])
                }
            );
        }
    }
}
