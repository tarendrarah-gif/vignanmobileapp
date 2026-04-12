using System.Threading.Tasks;
using VigInsight.Core.Models;
using System.Collections.Generic;

namespace VigInsight.Core.Interfaces
{
    public interface IOrganizationRepository
    {
        Task<int> InsertOrganizationAsync(OrganizationModel organization);
        Task<IEnumerable<OrganizationModel>> GetAllOrganizationsAsync();
    }
}
