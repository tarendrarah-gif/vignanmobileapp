using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VigInsight.Core.Interfaces;
using VigInsight.Core.Models;

namespace VigInsight.AuthAPI.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUserRepository _userRepository;

        public OrganizationService(IOrganizationRepository organizationRepository, IUserRepository userRepository)
        {
            _organizationRepository = organizationRepository;
            _userRepository = userRepository;
        }

        public async Task<OperationResult<IEnumerable<OrganizationModel>>> GetOrganizationsByRoleAsync(int requestingUserId, string roleName)
        {
            try
            {
                if (roleName.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    var all = await _organizationRepository.GetAllOrganizationsAsync();
                    return OperationResult<IEnumerable<OrganizationModel>>.Ok(all);
                }
                // Client / User — return only their own organisation
                var user = await _userRepository.GetUserByIdAsync(requestingUserId);
                if (user == null) return OperationResult<IEnumerable<OrganizationModel>>.Fail("User not found.");
                var org = await _organizationRepository.GetOrganizationByIdAsync(user.OrganizationId);
                var result = org != null
                    ? new List<OrganizationModel> { org }
                    : new List<OrganizationModel>();
                return OperationResult<IEnumerable<OrganizationModel>>.Ok(result);
            }
            catch (Exception ex) { return OperationResult<IEnumerable<OrganizationModel>>.Fail(ex.Message); }
        }

        public async Task<OperationResult<OrganizationModel>> GetOrganizationByIdAsync(int organizationId)
        {
            try
            {
                var org = await _organizationRepository.GetOrganizationByIdAsync(organizationId);
                return org == null
                    ? OperationResult<OrganizationModel>.Fail("Organization not found.")
                    : OperationResult<OrganizationModel>.Ok(org);
            }
            catch (Exception ex) { return OperationResult<OrganizationModel>.Fail(ex.Message); }
        }

        public async Task<OperationResult<int>> AddOrganizationAsync(OrganizationModel organization)
        {
            try
            {
                var id = await _organizationRepository.InsertOrganizationAsync(organization);
                return OperationResult<int>.Ok(id, "Organization added successfully.");
            }
            catch (Exception ex) { return OperationResult<int>.Fail(ex.Message); }
        }

        public async Task<OperationResult<bool>> UpdateOrganizationAsync(OrganizationModel organization)
        {
            try
            {
                organization.ModifiedOn = DateTime.UtcNow;
                var ok = await _organizationRepository.UpdateOrganizationAsync(organization);
                return ok
                    ? OperationResult<bool>.Ok(true, "Organization updated.")
                    : OperationResult<bool>.Fail("Organization not found.");
            }
            catch (Exception ex) { return OperationResult<bool>.Fail(ex.Message); }
        }

        public async Task<OperationResult<bool>> DeleteOrganizationAsync(int organizationId)
        {
            try
            {
                var ok = await _organizationRepository.DeleteOrganizationAsync(organizationId);
                return ok
                    ? OperationResult<bool>.Ok(true, "Organization deleted.")
                    : OperationResult<bool>.Fail("Organization not found.");
            }
            catch (Exception ex) { return OperationResult<bool>.Fail(ex.Message); }
        }

        // Legacy — used by dropdown loaders in AddUser / AddMachine
        public async Task<IEnumerable<OrganizationModel>> GetAllOrganizationsAsync()
            => await _organizationRepository.GetAllOrganizationsAsync();
    }
}
