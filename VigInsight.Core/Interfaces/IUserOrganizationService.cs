using System.Threading.Tasks;

namespace VigInsight.Core.Interfaces
{
    public interface IUserOrganizationService
    {
        Task AddUserOrganizationAsync(int userId, int organizationId);
    }
}
