using VigInsight.Core.Interfaces;
using VigInsight.Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace VigInsight.AuthAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserOrganizationService _userOrganizationService;
        private readonly IRoleService _roleService;

        public UserService(IUserRepository userRepository, IUserOrganizationService userOrganizationService, IRoleService roleService)
        {
            _userRepository = userRepository;
            _userOrganizationService = userOrganizationService;
            _roleService = roleService;
        }

        public async Task<UserModel?> ValidateUserAsync(string username, string password)
            => await _userRepository.GetUserAsync(username, password);

        /// <summary>Admin sees all users; Client sees only their own organisation's users.</summary>
        public async Task<OperationResult<IEnumerable<UserModel>>> GetUsersByRoleAsync(int requestingUserId, string roleName)
        {
            try
            {
                if (roleName.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    var all = await _userRepository.GetAllUsersAsync();
                    return OperationResult<IEnumerable<UserModel>>.Ok(all);
                }

                if (roleName.Equals("Client", StringComparison.OrdinalIgnoreCase))
                {
                    var requestor = await _userRepository.GetUserByIdAsync(requestingUserId);
                    if (requestor == null) return OperationResult<IEnumerable<UserModel>>.Fail("Requesting user not found.");
                    var orgUsers = await _userRepository.GetAllUsersAsync(requestor.OrganizationId);
                    return OperationResult<IEnumerable<UserModel>>.Ok(orgUsers);
                }

                // User role — read-only, same as Client scope
                var me = await _userRepository.GetUserByIdAsync(requestingUserId);
                if (me == null) return OperationResult<IEnumerable<UserModel>>.Fail("User not found.");
                var limited = await _userRepository.GetAllUsersAsync(me.OrganizationId);
                return OperationResult<IEnumerable<UserModel>>.Ok(limited);
            }
            catch (Exception ex)
            {
                return OperationResult<IEnumerable<UserModel>>.Fail(ex.Message);
            }
        }

        public async Task<OperationResult<UserModel>> GetUserByIdAsync(int userId)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(userId);
                return user == null
                    ? OperationResult<UserModel>.Fail("User not found.")
                    : OperationResult<UserModel>.Ok(user);
            }
            catch (Exception ex) { return OperationResult<UserModel>.Fail(ex.Message); }
        }

        public async Task<OperationResult<int>> AddUserAsync(UserModel user, int organizationId)
        {
            try
            {
                var role = await _roleService.GetRoleByIdAsync(user.RoleId);
                if (role == null) return OperationResult<int>.Fail("Invalid RoleId.");

                var userId = await _userRepository.InsertUserAsync(user);
                await _userOrganizationService.AddUserOrganizationAsync(userId, organizationId);
                return OperationResult<int>.Ok(userId, "User added successfully.");
            }
            catch (Exception ex) { return OperationResult<int>.Fail(ex.Message); }
        }

        public async Task<OperationResult<bool>> UpdateUserAsync(UserModel user)
        {
            try
            {
                user.ModifiedOn = DateTime.UtcNow;
                var ok = await _userRepository.UpdateUserAsync(user);
                return ok ? OperationResult<bool>.Ok(true, "User updated.") : OperationResult<bool>.Fail("User not found.");
            }
            catch (Exception ex) { return OperationResult<bool>.Fail(ex.Message); }
        }

        public async Task<OperationResult<bool>> DeleteUserAsync(int userId)
        {
            try
            {
                var ok = await _userRepository.DeleteUserAsync(userId);
                return ok ? OperationResult<bool>.Ok(true, "User deleted.") : OperationResult<bool>.Fail("User not found.");
            }
            catch (Exception ex) { return OperationResult<bool>.Fail(ex.Message); }
        }

        // Legacy backward-compat
        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
            => await _userRepository.GetAllUsersAsync();
    }
}
