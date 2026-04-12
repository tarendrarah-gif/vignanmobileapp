using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigInsight.Core.Models
{
    public class Page53Model
    {
        // Left Table
        public string ClampSpeed { get; set; }
        public string ClampPressure { get; set; }

        public string SafetySpeed { get; set; }
        public string SafetyPressure { get; set; }

        public string LockingSpeed { get; set; }
        public string LockingPressure { get; set; }

        public string ClampTonnageSpeed { get; set; }
        public string ClampTonnagePressure { get; set; }

        public string CarriageSpeed { get; set; }
        public string CarriagePressure { get; set; }

        public string PreInjectionSpeed { get; set; }
        public string PreInjectionPressure { get; set; }

        public string IntrugenSpeed { get; set; }
        public string IntrugenPressure { get; set; }

        public string InjectionSpeed { get; set; }
        public string InjectionPressure { get; set; }

        public string RefillSpeed { get; set; }
        public string RefillPressure { get; set; }

        public string SuckbackSpeed { get; set; }
        public string SuckbackPressure { get; set; }

        // Right Table
        public string DecompressionSpeed { get; set; }
        public string DecompressionPressure { get; set; }

        public string EjectorSpeed { get; set; }
        public string EjectorPressure { get; set; }

        public string CoresSpeed { get; set; }
        public string CoresPressure { get; set; }

        public string MoldHeightSpeed { get; set; }
        public string MoldHeightPressure { get; set; }

        // Set/Mode Section
        public string SetClampOpenSpeed { get; set; }
        public string ModeClampOpenPressure { get; set; }

        public string SetClampCloseSpeed { get; set; }
        public string ModeClampClosePressure { get; set; }

        // Metadata
        public int DataId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }

}
