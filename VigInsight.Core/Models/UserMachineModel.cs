using System;

namespace VigInsight.Core.Models
{
    public class UserMachineModel
    {
        public int UserMachineId { get; set; }
        public int UserId { get; set; }
        public int MachineId { get; set; }
        public DateTime AssignedOn { get; set; }
    }
}
