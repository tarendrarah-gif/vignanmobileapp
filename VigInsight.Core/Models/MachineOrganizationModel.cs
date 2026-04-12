using System;

namespace VigInsight.Core.Models
{
    public class MachineOrganizationModel
    {
        public int MachineOrganizationId { get; set; }
        public int MachineId { get; set; }
        public int OrganizationId { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
