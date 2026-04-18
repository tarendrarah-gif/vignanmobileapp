using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using VigInsight.Core.Interfaces;
using VigInsight.Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace VigInsight.Data.Repositories
{
    public class MachineRepository : IMachineRepository
    {
        private readonly string _connStr;

        public MachineRepository(IConfiguration configuration)
        {
            _connStr = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<MachineModel>> GetAllMachinesAsync(int? orgId = null)
        {
            using var conn = new SqlConnection(_connStr);
            return await conn.QueryAsync<MachineModel>(
                "usp_GetAllMachines",
                new { OrgId = orgId },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<MachineModel?> GetMachineByIdAsync(int machineId)
        {
            using var conn = new SqlConnection(_connStr);
            return await conn.QueryFirstOrDefaultAsync<MachineModel>(
                "usp_GetMachineById",
                new { MachineId = machineId },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<int> InsertMachineAsync(MachineModel machine)
        {
            using var conn = new SqlConnection(_connStr);
            return await conn.ExecuteScalarAsync<int>(
                "usp_InsertMachine",
                new { machine.MachineName, machine.MachineDescription, machine.IsActive, machine.CreatedBy, machine.CreatedOn, machine.ModifiedBy, machine.ModifiedOn },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<bool> UpdateMachineAsync(MachineModel machine, int organizationId)
        {
            using var conn = new SqlConnection(_connStr);
            var rows = await conn.ExecuteScalarAsync<int>(
                "usp_UpdateMachine",
                new { machine.MachineId, machine.MachineName, machine.MachineDescription, machine.IsActive, OrganizationId = organizationId, machine.ModifiedBy, machine.ModifiedOn },
                commandType: System.Data.CommandType.StoredProcedure);
            return rows >= 0;
        }

        public async Task<bool> DeleteMachineAsync(int machineId)
        {
            using var conn = new SqlConnection(_connStr);
            var rows = await conn.ExecuteScalarAsync<int>(
                "usp_DeleteMachine",
                new { MachineId = machineId },
                commandType: System.Data.CommandType.StoredProcedure);
            return rows >= 0;
        }

        public async Task<IEnumerable<MachineCardDto>> GetMachinesByOrganizationAsync(int organizationId)
        {
            using var conn = new SqlConnection(_connStr);
            var sql = @"
                SELECT m.MachineId, m.MachineName,
                       CAST(ROUND(RAND(CHECKSUM(NEWID())) * 1000, 2) AS float) AS HourlyProduction,
                       CASE ABS(CHECKSUM(NEWID())) % 3
                           WHEN 0 THEN 'Excellent' WHEN 1 THEN 'Moderate' ELSE 'Problem' END AS Performance,
                       NULL AS Alert,
                       CASE WHEN ABS(CHECKSUM(NEWID())) % 2 = 0 THEN 1 ELSE 0 END AS IsOnline,
                       CAST(ROUND(RAND(CHECKSUM(NEWID())) * 50, 2) AS float) AS PowerConsumption
                FROM tblMachineOrganization mo
                INNER JOIN tblMachines m ON mo.MachineId = m.MachineId
                WHERE mo.OrganizationId = @OrganizationId";
            return await conn.QueryAsync<MachineCardDto>(sql, new { OrganizationId = organizationId });
        }
    }
}
