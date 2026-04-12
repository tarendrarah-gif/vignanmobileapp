using VigInsight.Core.Models;

namespace VigInsight.Core.Models
{
    public class AddUserRequest
    {
        public UserModel User { get; set; }
        public int OrganizationId { get; set; }
    }
}
