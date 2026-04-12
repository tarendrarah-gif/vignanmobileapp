using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using VigInsight.Core.Interfaces;
using System.Threading.Tasks;

namespace VigInsight.Data.Repositories
{
    public class MachineOrganizationRepository : IMachineOrganizationRepository
    {
        private readonly string _connStr;

        public MachineOrganizationRepository(IConfiguration configuration)
        {
            _connStr = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task AddMachineOrganizationAsync(int machineId, int organizationId)
        {
            using var conn = new SqlConnection(_connStr);
            var parameters = new { MachineId = machineId, OrganizationId = organizationId };
            await conn.ExecuteAsync(
                "usp_InsertMachineOrganization",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }
    }
}
