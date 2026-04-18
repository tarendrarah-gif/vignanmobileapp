using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VigInsight.Core.Interfaces;
using VigInsight.Core.Models;

namespace VigInsight.AuthAPI.Services
{
    public class MachineService : IMachineService
    {
        private readonly IMachineRepository _machineRepository;
        private readonly IMachineOrganizationService _machineOrganizationService;
        private readonly IUserRepository _userRepository;

        public MachineService(
            IMachineRepository machineRepository,
            IMachineOrganizationService machineOrganizationService,
            IUserRepository userRepository)
        {
            _machineRepository = machineRepository;
            _machineOrganizationService = machineOrganizationService;
            _userRepository = userRepository;
        }

        public async Task<OperationResult<IEnumerable<MachineModel>>> GetMachinesByRoleAsync(int requestingUserId, string roleName)
        {
            try
            {
                if (roleName.Equals("Admin", StringComparison.OrdinalIgnoreCase))
                {
                    var all = await _machineRepository.GetAllMachinesAsync();
                    return OperationResult<IEnumerable<MachineModel>>.Ok(all);
                }
                var requestor = await _userRepository.GetUserByIdAsync(requestingUserId);
                if (requestor == null) return OperationResult<IEnumerable<MachineModel>>.Fail("Requesting user not found.");
                var orgMachines = await _machineRepository.GetAllMachinesAsync(requestor.OrganizationId);
                return OperationResult<IEnumerable<MachineModel>>.Ok(orgMachines);
            }
            catch (Exception ex) { return OperationResult<IEnumerable<MachineModel>>.Fail(ex.Message); }
        }

        public async Task<OperationResult<MachineModel>> GetMachineByIdAsync(int machineId)
        {
            try
            {
                var m = await _machineRepository.GetMachineByIdAsync(machineId);
                return m == null
                    ? OperationResult<MachineModel>.Fail("Machine not found.")
                    : OperationResult<MachineModel>.Ok(m);
            }
            catch (Exception ex) { return OperationResult<MachineModel>.Fail(ex.Message); }
        }

        public async Task<OperationResult<int>> AddMachineAsync(MachineModel machine, int organizationId)
        {
            try
            {
                var machineId = await _machineRepository.InsertMachineAsync(machine);
                await _machineOrganizationService.AddMachineOrganizationAsync(machineId, organizationId);
                return OperationResult<int>.Ok(machineId, "Machine added successfully.");
            }
            catch (Exception ex) { return OperationResult<int>.Fail(ex.Message); }
        }

        public async Task<OperationResult<bool>> UpdateMachineAsync(MachineModel machine, int organizationId)
        {
            try
            {
                machine.ModifiedOn = DateTime.UtcNow;
                var ok = await _machineRepository.UpdateMachineAsync(machine, organizationId);
                return ok
                    ? OperationResult<bool>.Ok(true, "Machine updated.")
                    : OperationResult<bool>.Fail("Machine not found.");
            }
            catch (Exception ex) { return OperationResult<bool>.Fail(ex.Message); }
        }

        public async Task<OperationResult<bool>> DeleteMachineAsync(int machineId)
        {
            try
            {
                var ok = await _machineRepository.DeleteMachineAsync(machineId);
                return ok
                    ? OperationResult<bool>.Ok(true, "Machine deleted.")
                    : OperationResult<bool>.Fail("Machine not found.");
            }
            catch (Exception ex) { return OperationResult<bool>.Fail(ex.Message); }
        }

        // Legacy — used by ClientDashboard
        public async Task<IEnumerable<MachineCardDto>> GetMachinesByOrganizationAsync(int organizationId)
            => await _machineRepository.GetMachinesByOrganizationAsync(organizationId);
    }
}
