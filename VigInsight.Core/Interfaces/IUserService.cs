using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VigInsight.Core.Models;

namespace VigInsight.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserModel?> ValidateUserAsync(string username, string password);
        Task<int> AddUserAsync(UserModel user, int organizationId);
        Task<IEnumerable<UserModel>> GetAllUsersAsync();
    }
}
