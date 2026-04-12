using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigInsight.Core.Models
{
    public class Page20Model
    {
        public int DataId { get; set; }

        // Flow
        public string FlowSlowFwd { get; set; }
        public string FlowFastFwd { get; set; }
        public string FlowFastRet { get; set; }
        public string FlowSlowRet { get; set; }

        // Pressure
        public string PressureSlowFwd { get; set; }
        public string PressureFastFwd { get; set; }
        public string PressureFastRet { get; set; }
        public string PressureSlowRet { get; set; }

        // Position
        public string PositionSlowFwd { get; set; }
        public string PositionFastFwd { get; set; }
        public string PositionFastRet { get; set; }
        public string PositionSlowRet { get; set; }

        // Time
        public string TimeSlowFwd { get; set; }
        public string TimeFastFwd { get; set; }
        public string TimeFastRet { get; set; }
        public string TimeSlowRet { get; set; }

        // Speed
        public string SpeedSlowFwd { get; set; }
        public string SpeedFastFwd { get; set; }
        public string SpeedFastRet { get; set; }
        public string SpeedSlowRet { get; set; }

        // Other fields
        public string PresentOperation { get; set; }
        public string CarriagePosition { get; set; }
        public string CarriageMode { get; set; }
        public string CarriageMove { get; set; }
        public string ForwardDuringInjection { get; set; }
        public string ForwardDuringSuckback { get; set; }
        public string ForwardDuringRefill { get; set; }
        public string CarriageForwardStartDelay { get; set; }
        public string CarriageRetractStartDelay { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }

}
