using System;

namespace VigInsight.Core.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public bool IsActive { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string? ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public int OrganizationId { get; set; } // Add for login organization context

        public string? OrganizationName { get; set; } // Add for login organization context
    }
}
