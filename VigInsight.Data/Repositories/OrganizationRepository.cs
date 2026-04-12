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

        public async Task<int> InsertOrganizationAsync(OrganizationModel organization)
        {
            using var conn = new SqlConnection(_connStr);
            var parameters = new
            {
                OrganizationName = organization.OrganizationName,
                OrganizationDescription = organization.OrganizationDescription,
                IsActive = organization.IsActive,
                CreatedBy = organization.CreatedBy,
                CreatedOn = organization.CreatedOn,
                ModifiedBy = organization.ModifiedBy,
                ModifiedOn = organization.ModifiedOn
            };
            var orgId = await conn.ExecuteScalarAsync<int>(
                "usp_InsertOrganization",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
            );
            return orgId;
        }

        public async Task<IEnumerable<OrganizationModel>> GetAllOrganizationsAsync()
        {
            using var conn = new SqlConnection(_connStr);
            var orgs = await conn.QueryAsync<OrganizationModel>(
                "usp_GetAllOrganizations",
                commandType: System.Data.CommandType.StoredProcedure
            );
            return orgs;
        }
    }
}
