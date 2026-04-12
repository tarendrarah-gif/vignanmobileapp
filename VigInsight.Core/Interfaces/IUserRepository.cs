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
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
    }
}
