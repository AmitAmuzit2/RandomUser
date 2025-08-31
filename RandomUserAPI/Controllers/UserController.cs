using Microsoft.AspNetCore.Mvc;
using RandomUserAPI.Services;

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
        [HttpGet]
        [Route("amit")]
        public IActionResult Test()
        {
            try
            {
                var randomUser = _randomUserService.testService();
                return Ok(randomUser);
            }
            catch (Exception)
            {
                // Log the exception here if needed
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

    }

}
