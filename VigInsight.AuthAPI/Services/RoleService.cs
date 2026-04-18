using System.Collections.Generic;
using System.Threading.Tasks;
using VigInsight.Core.Interfaces;
using VigInsight.Core.Models;

namespace VigInsight.AuthAPI.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<RoleModel>> GetActiveRolesAsync()
        {
            return await _roleRepository.GetAllRolesAsync();
        }

        public async Task<RoleModel?> GetRoleByIdAsync(int roleId)
        {
            return await _roleRepository.GetRoleByIdAsync(roleId);
        }

        public async Task<int> AddRoleAsync(RoleModel role)
        {
            return await _roleRepository.AddRoleAsync(role);
        }

        public async Task<bool> UpdateRoleAsync(RoleModel role)
        {
            return await _roleRepository.UpdateRoleAsync(role);
        }
    }
}
