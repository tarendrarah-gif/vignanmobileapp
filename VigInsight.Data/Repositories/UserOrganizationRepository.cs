using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using VigInsight.Core.Interfaces;
using System.Threading.Tasks;

namespace VigInsight.Data.Repositories
{
    public class UserOrganizationRepository : IUserOrganizationRepository
    {
        private readonly string _connStr;

        public UserOrganizationRepository(IConfiguration configuration)
        {
            _connStr = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task AddUserOrganizationAsync(int userId, int organizationId)
        {
            using var conn = new SqlConnection(_connStr);
            var parameters = new { UserId = userId, OrganizationId = organizationId };
            await conn.ExecuteAsync(
                "usp_InsertUserOrganization",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
            );
        }
    }
}
