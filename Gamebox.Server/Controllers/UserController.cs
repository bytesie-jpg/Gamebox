using Gamebox.Server.Models;
using Gamebox.Server.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Gamebox.Server.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }


        [HttpPost("/auth")]
        public async Task<ActionResult<User>> Post(User user)
        {
            var auth_user = await _userService.Authenticate(user);

            if (auth_user == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
