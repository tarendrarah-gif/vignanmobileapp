using System.Threading.Tasks;
using VigInsight.Core.Models;
using System.Collections.Generic;

namespace VigInsight.Core.Interfaces
{
    public interface IOrganizationService
    {
        Task<int> AddOrganizationAsync(OrganizationModel organization);
        Task<IEnumerable<OrganizationModel>> GetAllOrganizationsAsync();
    }
}
