using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigInsight.Core.Models
{
    public class Page7Model
    {
        public int DataId { get; set; }

        // Header Fields
        public string EjectorSelection { get; set; }
        public string NoOfRepeatsSet { get; set; }
        public string Executed { get; set; }
        public string PresentStage { get; set; }
        public string EjectorTime { get; set; }

        // Flow (%)
        public string FlowFwd1 { get; set; }
        public string FlowFwd2 { get; set; }
        public string FlowRet2 { get; set; }
        public string FlowRet1 { get; set; }
        public string FlowBack { get; set; }
        public string FlowFront { get; set; }

        // Pressure (bar)
        public string PressureFwd1 { get; set; }
        public string PressureFwd2 { get; set; }
        public string PressureRet2 { get; set; }
        public string PressureRet1 { get; set; }
        public string PressureBack { get; set; }
        public string PressureFront { get; set; }

        // Position (mm)
        public string PositionFwd1 { get; set; }
        public string PositionFwd2 { get; set; }
        public string PositionRet2 { get; set; }
        public string PositionRet1 { get; set; }
        public string PositionBack { get; set; }
        public string PositionFront { get; set; }

        // Time (sec)
        public string TimeFwd1 { get; set; }
        public string TimeFwd2 { get; set; }
        public string TimeRet2 { get; set; }
        public string TimeRet1 { get; set; }
        public string TimeBack { get; set; }
        public string TimeFront { get; set; }

        // Off Delay (sec)
        public string OffDelayFwd1 { get; set; }
        public string OffDelayFwd2 { get; set; }
        public string OffDelayRet2 { get; set; }
        public string OffDelayRet1 { get; set; }
        public string OffDelayBack { get; set; }
        public string OffDelayFront { get; set; }

        // Speeds (mm/s)
        public string SpeedFwd1 { get; set; }
        public string SpeedFwd2 { get; set; }
        public string SpeedRet2 { get; set; }
        public string SpeedRet1 { get; set; }
        public string SpeedBack { get; set; }
        public string SpeedFront { get; set; }

        // Additional Fields
        public string HydEjectPos { get; set; }
        public string EjectorStartPosition { get; set; }
        public string EjectorStartDelay { get; set; }
        public string EjectorRetractSolenoids { get; set; }
        public string EjectorRetractLSW10 { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }

}
