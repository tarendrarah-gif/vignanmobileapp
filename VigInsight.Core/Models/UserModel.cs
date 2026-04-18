using System;

namespace VigInsight.Core.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int RoleId { get; set; }

        /// <summary>Flat string mapped directly from Dapper (stored proc JOIN on tblRoleMaster).</summary>
        public string? RoleName { get; set; }

        /// <summary>Navigation – only populated when explicitly mapped (not used in Dapper flat queries).</summary>
        public RoleModel? Role { get; set; } // navigation (optional in Dapper mapping)

        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int OrganizationId { get; set; } // Add for login organization context

        public string? OrganizationName { get; set; } // Add for login organization context
    }
}
