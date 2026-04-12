using System.Threading.Tasks;

namespace VigInsight.Core.Interfaces
{
    public interface IMachineOrganizationRepository
    {
        Task AddMachineOrganizationAsync(int machineId, int organizationId);
    }
}
