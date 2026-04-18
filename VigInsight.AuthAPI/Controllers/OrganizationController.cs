using Microsoft.AspNetCore.Mvc;
using VigInsight.Core.Models;
using VigInsight.Core.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace VigInsight.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OrganizationController(IOrganizationService organizationService) => _organizationService = organizationService;

        // GET /api/organization?userId=1&role=Admin
        [HttpGet]
        public async Task<IActionResult> GetOrganizations([FromQuery] int userId = 0, [FromQuery] string role = "Admin")
        {
            if (userId > 0)
            {
                var result = await _organizationService.GetOrganizationsByRoleAsync(userId, role);
                return result.Success ? Ok(result.Data) : BadRequest(result.Message);
            }
            var orgs = await _organizationService.GetAllOrganizationsAsync();
            return Ok(orgs);
        }

        // GET /api/organization/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganization(int id)
        {
            var result = await _organizationService.GetOrganizationByIdAsync(id);
            return result.Success ? Ok(result.Data) : NotFound(result.Message);
        }

        // POST /api/organization
        [HttpPost]
        public async Task<IActionResult> AddOrganization([FromBody] OrganizationModel organization)
        {
            var result = await _organizationService.AddOrganizationAsync(organization);
            return result.Success ? Ok(new { OrganizationId = result.Data }) : BadRequest(result.Message);
        }

        // PUT /api/organization/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrganization(int id, [FromBody] OrganizationModel organization)
        {
            if (id != organization.OrganizationId) return BadRequest("ID mismatch.");
            var result = await _organizationService.UpdateOrganizationAsync(organization);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        // DELETE /api/organization/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganization(int id)
        {
            var result = await _organizationService.DeleteOrganizationAsync(id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }
    }
}
