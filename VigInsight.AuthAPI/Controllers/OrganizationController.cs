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

        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrganization([FromBody] OrganizationModel organization)
        {
            try
            {
                var orgId = await _organizationService.AddOrganizationAsync(organization);
                return Ok(new { OrganizationId = orgId });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Error adding organization: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrganizationModel>>> GetAllOrganizations()
        {
            try
            {
                var orgs = await _organizationService.GetAllOrganizationsAsync();
                return Ok(orgs);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Error fetching organizations: {ex.Message}");
            }
        }
    }
}
