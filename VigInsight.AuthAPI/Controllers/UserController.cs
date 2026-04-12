using Microsoft.AspNetCore.Mvc;
using VigInsight.Core.Models;
using VigInsight.Core.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
    
namespace VigInsight.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            try
            {
                var userId = await _userService.AddUserAsync(request.User, request.OrganizationId);
                return Ok(new { UserId = userId });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Error adding user: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetAllUsersAsync();
                return Ok(users);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Error fetching users: {ex.Message}");
            }
        }
    }
}
