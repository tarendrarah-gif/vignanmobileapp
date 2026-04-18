using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VigInsight.Core.Interfaces;
using VigInsight.Core.Models;
using System.Collections.Generic;

namespace VigInsight.AuthAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleModel>>> GetActiveRoles()
        {
            var roles = await _roleService.GetActiveRolesAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoleModel>> GetRole(int id)
        {
            var role = await _roleService.GetRoleByIdAsync(id);
            if (role == null) return NotFound();
            return Ok(role);
        }

        [HttpPost]
        public async Task<ActionResult> AddRole([FromBody] RoleModel role)
        {
            var id = await _roleService.AddRoleAsync(role);
            return CreatedAtAction(nameof(GetRole), new { id }, role);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRole(int id, [FromBody] RoleModel role)
        {
            if (id != role.RoleId) return BadRequest("Role ID mismatch");
            var ok = await _roleService.UpdateRoleAsync(role);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
