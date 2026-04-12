using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigInsight.Core.Models
{
    public class Page3Model
    {
        public int DataId { get; set; }

        // Flow values
        public string FlowSlow1 { get; set; }
        public string FlowFast { get; set; }
        public string FlowSlow2 { get; set; }
        public string FlowSafety { get; set; }
        public string FlowLocking { get; set; }

        // Pressure values
        public string PressureSlow1 { get; set; }
        public string PressureFast { get; set; }
        public string PressureSlow2 { get; set; }
        public string PressureSafety { get; set; }
        public string PressureLocking { get; set; }

        // Position values
        public string PositionSlow1 { get; set; }
        public string PositionFast { get; set; }
        public string PositionSlow2 { get; set; }
        public string PositionSafety { get; set; }
        public string PositionLocking { get; set; }

        // Speed values
        public string SpeedSlow1 { get; set; }
        public string SpeedFast { get; set; }
        public string SpeedSlow2 { get; set; }
        public string SpeedSafety { get; set; }
        public string SpeedLocking { get; set; }

        // Act Stage Times
        public string ActStageTimeSlow1 { get; set; }
        public string ActStageTimeFast { get; set; }
        public string ActStageTimeSlow2 { get; set; }
        public string ActStageTimeSafety { get; set; }
        public string ActStageTimeLocking { get; set; }

        // Actual Force and Clamp Position
        public string ActualForce { get; set; }
        public string ClampPosition { get; set; }

        // Timing rows
        public string MoldCloseTimeSet { get; set; }
        public string MoldCloseTimeActual { get; set; }
        public string MoldCloseTimeLast { get; set; }

        public string MoldSafetyTimeSet { get; set; }
        public string MoldSafetyTimeActual { get; set; }
        public string MoldSafetyTimeLast { get; set; }

        public string LockingTimeSet { get; set; }
        public string LockingTimeActual { get; set; }
        public string LockingTimeLast { get; set; }

        // Set mode
        public string SetModeFlow { get; set; }
        public string SetModePressure { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }



}
