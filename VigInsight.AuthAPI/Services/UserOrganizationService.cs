using System.Threading.Tasks;
using VigInsight.Core.Interfaces;

namespace VigInsight.AuthAPI.Services
{
    public class UserOrganizationService : IUserOrganizationService
    {
        private readonly IUserOrganizationRepository _userOrganizationRepository;

        public UserOrganizationService(IUserOrganizationRepository userOrganizationRepository)
        {
            _userOrganizationRepository = userOrganizationRepository;
        }

        public async Task AddUserOrganizationAsync(int userId, int organizationId)
        {
            await _userOrganizationRepository.AddUserOrganizationAsync(userId, organizationId);
        }
    }
}
