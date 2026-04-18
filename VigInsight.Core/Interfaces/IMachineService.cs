using System.Collections.Generic;
using System.Threading.Tasks;
using VigInsight.Core.Models;

namespace VigInsight.Core.Interfaces
{
    public interface IMachineService
    {
        Task<OperationResult<IEnumerable<MachineModel>>> GetMachinesByRoleAsync(int requestingUserId, string roleName);
        Task<OperationResult<MachineModel>> GetMachineByIdAsync(int machineId);
        Task<OperationResult<int>> AddMachineAsync(MachineModel machine, int organizationId);
        Task<OperationResult<bool>> UpdateMachineAsync(MachineModel machine, int organizationId);
        Task<OperationResult<bool>> DeleteMachineAsync(int machineId);
        // kept for legacy ClientDashboard calls
        Task<IEnumerable<MachineCardDto>> GetMachinesByOrganizationAsync(int organizationId);
    }
}
