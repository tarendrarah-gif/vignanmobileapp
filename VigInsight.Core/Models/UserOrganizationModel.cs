using System;

namespace VigInsight.Core.Models
{
    public class UserOrganizationModel
    {
        public int UserOrganizationId { get; set; }
        public int UserId { get; set; }
        public int OrganizationId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
