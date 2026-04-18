using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using VigInsight.Core.Interfaces;
using VigInsight.Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace VigInsight.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _connStr;

        public UserRepository(IConfiguration configuration)
        {
            _connStr = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<UserModel?> GetUserAsync(string username, string password)
        {
            using var conn = new SqlConnection(_connStr);
            return await conn.QueryFirstOrDefaultAsync<UserModel>(
                "usp_GetUserByCredentials",
                new { Username = username, Password = password },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync(int? orgId = null)
        {
            using var conn = new SqlConnection(_connStr);
            return await conn.QueryAsync<UserModel>(
                "usp_GetAllUsers",
                new { OrgId = orgId },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<UserModel?> GetUserByIdAsync(int userId)
        {
            using var conn = new SqlConnection(_connStr);
            return await conn.QueryFirstOrDefaultAsync<UserModel>(
                "usp_GetUserById",
                new { UserId = userId },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<int> InsertUserAsync(UserModel user)
        {
            using var conn = new SqlConnection(_connStr);
            return await conn.ExecuteScalarAsync<int>(
                "usp_InsertUser",
                new { user.Username, user.Password, RoleID = user.RoleId, user.IsActive, user.CreatedBy, user.CreatedOn, user.ModifiedBy, user.ModifiedOn },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public async Task<bool> UpdateUserAsync(UserModel user)
        {
            using var conn = new SqlConnection(_connStr);
            var rows = await conn.ExecuteScalarAsync<int>(
                "usp_UpdateUser",
                new { user.UserId, user.Username, RoleID = user.RoleId, user.IsActive, user.ModifiedBy, user.ModifiedOn },
                commandType: System.Data.CommandType.StoredProcedure);
            return rows > 0;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            using var conn = new SqlConnection(_connStr);
            var rows = await conn.ExecuteScalarAsync<int>(
                "usp_DeleteUser",
                new { UserId = userId },
                commandType: System.Data.CommandType.StoredProcedure);
            return rows >= 0; // delete cascade may yield 0 on users with no org
        }
    }
}
