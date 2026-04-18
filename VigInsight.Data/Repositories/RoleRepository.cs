using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;
using VigInsight.Core.Interfaces;
using VigInsight.Core.Models;

namespace VigInsight.Data.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly string _connStr;

        public RoleRepository(IConfiguration configuration)
        {
            _connStr = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<RoleModel>> GetAllRolesAsync()
        {
            using var conn = new SqlConnection(_connStr);
            var sql = "SELECT RoleID AS RoleId, RoleName, Description, IsActive, CreatedDate, UpdatedDate FROM dbo.tblRoleMaster WHERE IsActive = 1 ORDER BY RoleID";
            var result = await conn.QueryAsync<RoleModel>(sql);
            return result;
        }

        public async Task<RoleModel?> GetRoleByIdAsync(int roleId)
        {
            using var conn = new SqlConnection(_connStr);
            var sql = "SELECT RoleID AS RoleId, RoleName, Description, IsActive, CreatedDate, UpdatedDate FROM dbo.tblRoleMaster WHERE RoleID = @RoleID";
            var result = await conn.QueryFirstOrDefaultAsync<RoleModel>(sql, new { RoleID = roleId });
            return result;
        }

        public async Task<int> AddRoleAsync(RoleModel role)
        {
            using var conn = new SqlConnection(_connStr);
            var sql = @"
                INSERT INTO dbo.tblRoleMaster (RoleName, Description, IsActive, CreatedDate)
                VALUES (@RoleName, @Description, @IsActive, GETDATE());
                SELECT CAST(SCOPE_IDENTITY() AS INT);
            ";
            var id = await conn.ExecuteScalarAsync<int>(sql, new { role.RoleName, role.Description, role.IsActive });
            return id;
        }

        public async Task<bool> UpdateRoleAsync(RoleModel role)
        {
            using var conn = new SqlConnection(_connStr);
            var sql = @"
                UPDATE dbo.tblRoleMaster
                SET RoleName = @RoleName,
                    Description = @Description,
                    IsActive = @IsActive,
                    UpdatedDate = GETDATE()
                WHERE RoleID = @RoleID
            ";
            var rows = await conn.ExecuteAsync(sql, new { RoleName = role.RoleName, Description = role.Description, IsActive = role.IsActive, RoleID = role.RoleId });
            return rows > 0;
        }
    }
}
