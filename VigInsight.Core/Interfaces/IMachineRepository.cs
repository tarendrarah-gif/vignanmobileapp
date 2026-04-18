using System.Collections.Generic;
using System.Threading.Tasks;
using VigInsight.Core.Models;

namespace VigInsight.Core.Interfaces
{
    public interface IMachineRepository
    {
        Task<IEnumerable<MachineModel>> GetAllMachinesAsync(int? orgId = null);
        Task<MachineModel?> GetMachineByIdAsync(int machineId);
        Task<int> InsertMachineAsync(MachineModel machine);
        Task<bool> UpdateMachineAsync(MachineModel machine, int organizationId);
        Task<bool> DeleteMachineAsync(int machineId);
        Task<IEnumerable<MachineCardDto>> GetMachinesByOrganizationAsync(int organizationId);
    }
}
