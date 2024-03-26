using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomUserAPI.Services;
using System.Text.Json;

namespace RandomUserAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _randomUserService;
        private readonly AuthService _authService;
        public UserController(UserService randomUserService, AuthService authService)
        {
            _randomUserService = randomUserService;
            _authService = authService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRandomUser([FromHeader] string username, [FromHeader] string password)
        {
            try
            {
                if (!_authService.Authenticate(username, password))
                    return Unauthorized();

                var randomUser = await _randomUserService.GetRandomUserAsync();
                return Ok(randomUser);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }


        }
    }
}
