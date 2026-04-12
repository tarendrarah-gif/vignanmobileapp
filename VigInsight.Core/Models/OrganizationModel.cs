using System;

namespace VigInsight.Core.Models
{
    public class OrganizationModel
    {
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string? OrganizationDescription { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
