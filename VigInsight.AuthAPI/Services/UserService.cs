using VigInsight.Core.Interfaces;
using VigInsight.Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace VigInsight.AuthAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserOrganizationService _userOrganizationService;

        public UserService(IUserRepository userRepository, IUserOrganizationService userOrganizationService)
        {
            _userRepository = userRepository;
            _userOrganizationService = userOrganizationService;
        }

        public async Task<UserModel?> ValidateUserAsync(string username, string password)
        {
            return await _userRepository.GetUserAsync(username, password);
        }

        public async Task<int> AddUserAsync(UserModel user, int organizationId)
        {
            var userId = await _userRepository.InsertUserAsync(user);
            await _userOrganizationService.AddUserOrganizationAsync(userId, organizationId);
            return userId;
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllUsersAsync();
        }
    }
}
