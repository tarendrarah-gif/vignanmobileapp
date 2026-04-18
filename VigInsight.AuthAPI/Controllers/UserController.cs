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

        // GET /api/user?userId=1&role=Admin
        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery] int userId = 0, [FromQuery] string role = "Admin")
        {
            if (userId > 0)
            {
                var result = await _userService.GetUsersByRoleAsync(userId, role);
                return result.Success ? Ok(result.Data) : BadRequest(result.Message);
            }
            // Legacy: no auth context ? return all (backward-compat with UserList.html)
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // GET /api/user/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var result = await _userService.GetUserByIdAsync(id);
            return result.Success ? Ok(result.Data) : NotFound(result.Message);
        }

        // POST /api/user
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequest request)
        {
            var result = await _userService.AddUserAsync(request.User, request.OrganizationId);
            return result.Success ? Ok(new { UserId = result.Data }) : BadRequest(result.Message);
        }

        // PUT /api/user/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserModel user)
        {
            if (id != user.UserId) return BadRequest("ID mismatch.");
            var result = await _userService.UpdateUserAsync(user);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        // DELETE /api/user/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
    }
}
