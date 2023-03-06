using BudgetManager.Enum;
using BudgetManager.Models.Users;
using BudgetManager.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetManagerAPI.Controllers
{
    [Authorize]
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] UserCredentials credentials)
        {
            var informations = await _userService.Authenticate(credentials);
            return Ok(informations);
        }

        [Authorize(Roles = $"{nameof(UserRole.Administrator)}")]
        [HttpPost("save")]
        public async Task<IActionResult> SaveUser([FromBody] User user)
        {
            await _userService.SaveUser(user);
            return Ok();
        }

        [HttpPost("changePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] string password)
        {
            var loggedUserId = int.Parse(User.Identity!.Name!);
            await _userService.ChangePassword(loggedUserId, password);
            return Ok();
        }
    }
}
