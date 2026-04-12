using System.Threading.Tasks;
using VigInsight.Core.Models;
using System.Collections.Generic;

namespace VigInsight.Core.Interfaces
{
    public interface IMachineService
    {
        Task<int> AddMachineAsync(MachineModel machine, int organizationId);
        Task<int> AddMachineAsync(MachineModel machine);
        Task<IEnumerable<MachineCardDto>> GetMachinesByOrganizationAsync(int organizationId);
    }
}
