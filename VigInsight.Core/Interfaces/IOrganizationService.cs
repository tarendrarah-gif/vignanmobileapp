using System.Collections.Generic;
using System.Threading.Tasks;
using VigInsight.Core.Models;

namespace VigInsight.Core.Interfaces
{
    public interface IOrganizationService
    {
        Task<OperationResult<IEnumerable<OrganizationModel>>> GetOrganizationsByRoleAsync(int requestingUserId, string roleName);
        Task<OperationResult<OrganizationModel>> GetOrganizationByIdAsync(int organizationId);
        Task<OperationResult<int>> AddOrganizationAsync(OrganizationModel organization);
        Task<OperationResult<bool>> UpdateOrganizationAsync(OrganizationModel organization);
        Task<OperationResult<bool>> DeleteOrganizationAsync(int organizationId);
        // kept for backward compat (Add Machine / Add User dropdowns)
        Task<IEnumerable<OrganizationModel>> GetAllOrganizationsAsync();
    }
}
