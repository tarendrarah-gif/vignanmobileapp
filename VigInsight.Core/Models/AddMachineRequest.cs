using VigInsight.Core.Models;

namespace VigInsight.Core.Models
{
    public class AddMachineRequest
    {
        public MachineModel Machine { get; set; }
        public int OrganizationId { get; set; }
    }
}
