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
            try
            {
                using var conn = new SqlConnection(_connStr);

                var user = await conn.QueryFirstOrDefaultAsync<UserModel>(
                    "usp_GetUserByCredentials", // Stored procedure name
                    new { Username = username, Password = password },
                    commandType: System.Data.CommandType.StoredProcedure
                );

                return user;
            }
            catch (Exception ex)
            {
                // Optionally log the exception here
                throw; // Rethrow for now
            }
        }

        public async Task<int> InsertUserAsync(UserModel user)
        {
            try
            {
                using var conn = new SqlConnection(_connStr);
                var parameters = new
                {
                    Username = user.Username,
                    Password = user.Password,
                    Role = user.Role,
                    IsActive = user.IsActive,
                    CreatedBy = user.CreatedBy,
                    CreatedOn = user.CreatedOn,
                    ModifiedBy = user.ModifiedBy,
                    ModifiedOn = user.ModifiedOn
                    // OrganizationId removed for mapping table approach
                };
                // Assumes usp_InsertUser returns the new UserId
                var userId = await conn.ExecuteScalarAsync<int>(
                    "usp_InsertUser",
                    parameters,
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return userId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<UserModel>> GetAllUsersAsync()
        {
            try
            {
                using var conn = new SqlConnection(_connStr);
                var users = await conn.QueryAsync<UserModel>(
                    "usp_GetAllUsers", // Use stored procedure
                    commandType: System.Data.CommandType.StoredProcedure
                );
                return users;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
