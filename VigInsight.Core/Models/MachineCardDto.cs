using System;

namespace VigInsight.Core.Models
{
    public class MachineCardDto
    {
        public int MachineId { get; set; }
        public string MachineName { get; set; }
        public double? HourlyProduction { get; set; }
        public string Performance { get; set; } // "Excellent", "Moderate", "Problem", "Stopped"
        public string Alert { get; set; }
        public bool IsOnline { get; set; } // New property
        public double? PowerConsumption { get; set; } // New property
    }
}
