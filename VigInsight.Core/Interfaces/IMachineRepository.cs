using System.Threading.Tasks;
using VigInsight.Core.Models;
using System.Collections.Generic;

namespace VigInsight.Core.Interfaces
{
    public interface IMachineRepository
    {
        Task<int> InsertMachineAsync(MachineModel machine);
        Task<IEnumerable<MachineCardDto>> GetMachinesByOrganizationAsync(int organizationId);
    }
}
