using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using VigInsight.Core.Interfaces;
using VigInsight.Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace VigInsight.Data.Repositories
{
    public class OrganizationRepository : IOrganizationRepository
    {
        private readonly string _connStr;

        public OrganizationRepository(IConfiguration configuration)
        {
            _connStr = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<OrganizationModel>> GetAllOrganizationsAsync()
        {
            using var conn = new SqlConnection(_connStr);
            return await conn.QueryAsync<OrganizationModel>(
                "usp_GetAllOrganizations",
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<OrganizationModel?> GetOrganizationByIdAsync(int organizationId)
        {
            using var conn = new SqlConnection(_connStr);
            return await conn.QueryFirstOrDefaultAsync<OrganizationModel>(
                "usp_GetOrganizationById",
                new { OrganizationId = organizationId },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<int> InsertOrganizationAsync(OrganizationModel organization)
        {
            using var conn = new SqlConnection(_connStr);
            return await conn.ExecuteScalarAsync<int>(
                "usp_InsertOrganization",
                new { organization.OrganizationName, organization.OrganizationDescription, organization.IsActive, organization.CreatedBy, organization.CreatedOn, organization.ModifiedBy, organization.ModifiedOn },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<bool> UpdateOrganizationAsync(OrganizationModel organization)
        {
            using var conn = new SqlConnection(_connStr);
            var rows = await conn.ExecuteScalarAsync<int>(
                "usp_UpdateOrganization",
                new { organization.OrganizationId, organization.OrganizationName, organization.OrganizationDescription, organization.IsActive, organization.ModifiedBy, organization.ModifiedOn },
                commandType: System.Data.CommandType.StoredProcedure);
            return rows > 0;
        }

        public async Task<bool> DeleteOrganizationAsync(int organizationId)
        {
            using var conn = new SqlConnection(_connStr);
            var rows = await conn.ExecuteScalarAsync<int>(
                "usp_DeleteOrganization",
                new { OrganizationId = organizationId },
                commandType: System.Data.CommandType.StoredProcedure);
            return rows >= 0;
        }
    }
}
