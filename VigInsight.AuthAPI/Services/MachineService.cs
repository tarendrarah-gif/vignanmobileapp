using System.Threading.Tasks;
using VigInsight.Core.Interfaces;
using VigInsight.Core.Models;
using System.Collections.Generic;

namespace VigInsight.AuthAPI.Services
{
    public class MachineService : IMachineService
    {
        private readonly IMachineRepository _machineRepository;
        private readonly IMachineOrganizationService _machineOrganizationService;

        public MachineService(IMachineRepository machineRepository, IMachineOrganizationService machineOrganizationService)
        {
            _machineRepository = machineRepository;
            _machineOrganizationService = machineOrganizationService;
        }

        public async Task<int> AddMachineAsync(MachineModel machine, int organizationId)
        {
            var machineId = await _machineRepository.InsertMachineAsync(machine);
            await _machineOrganizationService.AddMachineOrganizationAsync(machineId, organizationId);
            return machineId;
        }

        public async Task<int> AddMachineAsync(MachineModel machine)
        {
            return await AddMachineAsync(machine, 0);
        }

        public async Task<IEnumerable<MachineCardDto>> GetMachinesByOrganizationAsync(int organizationId)
        {
            return await _machineRepository.GetMachinesByOrganizationAsync(organizationId);
        }
    }
}
