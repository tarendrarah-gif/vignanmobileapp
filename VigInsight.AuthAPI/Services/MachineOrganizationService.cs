using System.Threading.Tasks;
using VigInsight.Core.Interfaces;

namespace VigInsight.AuthAPI.Services
{
    public class MachineOrganizationService : IMachineOrganizationService
    {
        private readonly IMachineOrganizationRepository _machineOrganizationRepository;

        public MachineOrganizationService(IMachineOrganizationRepository machineOrganizationRepository)
        {
            _machineOrganizationRepository = machineOrganizationRepository;
        }

        public async Task AddMachineOrganizationAsync(int machineId, int organizationId)
        {
            await _machineOrganizationRepository.AddMachineOrganizationAsync(machineId, organizationId);
        }
    }
}
