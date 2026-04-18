using System.Collections.Generic;
using System.Threading.Tasks;
using VigInsight.Core.Models;

namespace VigInsight.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserModel?> ValidateUserAsync(string username, string password);
        Task<OperationResult<IEnumerable<UserModel>>> GetUsersByRoleAsync(int requestingUserId, string roleName);
        Task<OperationResult<UserModel>> GetUserByIdAsync(int userId);
        Task<OperationResult<int>> AddUserAsync(UserModel user, int organizationId);
        Task<OperationResult<bool>> UpdateUserAsync(UserModel user);
        Task<OperationResult<bool>> DeleteUserAsync(int userId);
        // kept for backward compat with Login/UserController legacy callers
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
    }
}
