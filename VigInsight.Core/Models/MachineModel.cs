using System;

namespace VigInsight.Core.Models
{
    public class MachineModel
    {
        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public string? MachineDescription { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int OrganizationId { get; set; }
        public string? OrganizationName { get; set; }
    }
}
