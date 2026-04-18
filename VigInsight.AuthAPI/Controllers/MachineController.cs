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

        // GET /api/machine?userId=1&role=Admin
        [HttpGet]
        public async Task<IActionResult> GetMachines([FromQuery] int userId = 0, [FromQuery] string role = "Admin")
        {
            var result = await _machineService.GetMachinesByRoleAsync(userId, role);
            return result.Success ? Ok(result.Data) : BadRequest(result.Message);
        }

        // GET /api/machine/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMachine(int id)
        {
            var result = await _machineService.GetMachineByIdAsync(id);
            return result.Success ? Ok(result.Data) : NotFound(result.Message);
        }

        // POST /api/machine
        [HttpPost]
        public async Task<IActionResult> AddMachine([FromBody] AddMachineRequest request)
        {
            var result = await _machineService.AddMachineAsync(request.Machine, request.OrganizationId);
            return result.Success ? Ok(new { MachineId = result.Data }) : BadRequest(result.Message);
        }

        // PUT /api/machine/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMachine(int id, [FromBody] UpdateMachineRequest request)
        {
            if (id != request.Machine.MachineId) return BadRequest("ID mismatch.");
            var result = await _machineService.UpdateMachineAsync(request.Machine, request.OrganizationId);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        // DELETE /api/machine/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMachine(int id)
        {
            var result = await _machineService.DeleteMachineAsync(id);
            return result.Success ? Ok(result.Message) : BadRequest(result.Message);
        }

        // Legacy – used by ClientDashboard
        [HttpGet("ByOrganization/{organizationId}")]
        public async Task<IActionResult> GetMachinesByOrganization(int organizationId)
        {
            var machines = await _machineService.GetMachinesByOrganizationAsync(organizationId);
            return Ok(machines);
        }
    }
}
