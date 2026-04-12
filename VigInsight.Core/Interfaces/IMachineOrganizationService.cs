using System.Threading.Tasks;

namespace VigInsight.Core.Interfaces
{
    public interface IMachineOrganizationService
    {
        Task AddMachineOrganizationAsync(int machineId, int organizationId);
    }
}
