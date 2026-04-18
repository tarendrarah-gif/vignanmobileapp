using System.Collections.Generic;
using System.Threading.Tasks;
using VigInsight.Core.Models;

namespace VigInsight.Core.Interfaces
{
    public interface IOrganizationRepository
    {
        Task<IEnumerable<OrganizationModel>> GetAllOrganizationsAsync();
        Task<OrganizationModel?> GetOrganizationByIdAsync(int organizationId);
        Task<int> InsertOrganizationAsync(OrganizationModel organization);
        Task<bool> UpdateOrganizationAsync(OrganizationModel organization);
        Task<bool> DeleteOrganizationAsync(int organizationId);
    }
}
