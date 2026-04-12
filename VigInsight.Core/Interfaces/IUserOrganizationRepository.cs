using System.Threading.Tasks;
using VigInsight.Core.Models;

namespace VigInsight.Core.Interfaces
{
    public interface IUserOrganizationRepository
    {
        Task AddUserOrganizationAsync(int userId, int organizationId);
    }
}
