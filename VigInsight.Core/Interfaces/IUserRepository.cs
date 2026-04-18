using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VigInsight.Core.Models;

namespace VigInsight.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<UserModel?> GetUserAsync(string username, string password);
        Task<int> InsertUserAsync(UserModel user);
        Task<IEnumerable<UserModel>> GetAllUsersAsync(int? orgId = null);
        Task<UserModel?> GetUserByIdAsync(int userId);
        Task<bool> UpdateUserAsync(UserModel user);
        Task<bool> DeleteUserAsync(int userId);
    }
}
