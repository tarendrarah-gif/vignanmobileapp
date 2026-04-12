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

        public async Task<int> InsertMachineAsync(MachineModel machine)
        {
            try
            {
                using var conn = new SqlConnection(_connStr);
                var parameters = new
                {
                    MachineName = machine.MachineName,
                    MachineDescription = machine.MachineDescription,
                    IsActive = machine.IsActive,
                    CreatedBy = machine.CreatedBy,
                    CreatedOn = machine.CreatedOn,
                    ModifiedBy = machine.ModifiedBy,
                    ModifiedOn = machine.ModifiedOn
                };
                // Assumes usp_InsertMachine returns the new MachineId
                var machineId = await conn.ExecuteScalarAsync<int>(
                    "usp_InsertMachine",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return machineId;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<MachineCardDto>> GetMachinesByOrganizationAsync(int organizationId)
        {
            using var conn = new SqlConnection(_connStr);
            // Sample/mock query, replace with your actual production/performance/alert logic
            var sql = @"
                SELECT m.MachineId, m.MachineName,
                       CAST(ROUND(RAND(CHECKSUM(NEWID())) * 1000, 2) AS float) AS HourlyProduction,
                       CASE ABS(CHECKSUM(NEWID())) % 3
                           WHEN 0 THEN 'Excellent'
                           WHEN 1 THEN 'Moderate'
                           ELSE 'Problem'
                       END AS Performance,
                       NULL AS Alert,
                       CASE WHEN ABS(CHECKSUM(NEWID())) % 2 = 0 THEN 1 ELSE 0 END AS IsOnline,
                       CAST(ROUND(RAND(CHECKSUM(NEWID())) * 50, 2) AS float) AS PowerConsumption
                FROM tblMachineOrganization mo
                INNER JOIN tblMachines m ON mo.MachineId = m.MachineId
                WHERE mo.OrganizationId = @OrganizationId
            ";
            var result = await conn.QueryAsync<MachineCardDto>(sql, new { OrganizationId = organizationId });
            return result;
        }
    }
}
