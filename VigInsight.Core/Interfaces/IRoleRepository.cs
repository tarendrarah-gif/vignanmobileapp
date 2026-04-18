using System.Collections.Generic;
using System.Threading.Tasks;
using VigInsight.Core.Models;

namespace VigInsight.Core.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<RoleModel>> GetAllRolesAsync();
        Task<RoleModel?> GetRoleByIdAsync(int roleId);
        Task<int> AddRoleAsync(RoleModel role);
        Task<bool> UpdateRoleAsync(RoleModel role);
    }
}
