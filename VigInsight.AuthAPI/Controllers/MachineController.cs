using Microsoft.AspNetCore.Mvc;
using VigInsight.Core.Models;
using VigInsight.Core.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace VigInsight.AuthAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MachineController : ControllerBase
    {
        private readonly IMachineService _machineService;

        public MachineController(IMachineService machineService)
        {
            _machineService = machineService;
        }

        [HttpPost]
        public async Task<IActionResult> AddMachine([FromBody] AddMachineRequest request)
        {
            try
            {
                var machineId = await _machineService.AddMachineAsync(request.Machine, request.OrganizationId);
                return Ok(new { MachineId = machineId });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Error adding machine: {ex.Message}");
            }
        }

        [HttpGet("ByOrganization/{organizationId}")]
        public async Task<ActionResult<IEnumerable<MachineCardDto>>> GetMachinesByOrganization(int organizationId)
        {
            try
            {
                var machines = await _machineService.GetMachinesByOrganizationAsync(organizationId);
                return Ok(machines);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Error fetching machines: {ex.Message}");
            }
        }
    }
}
