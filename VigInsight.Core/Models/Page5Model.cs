using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigInsight.Core.Models
{
    public class Page5Model
    {
        public int DataId { get; set; }

        // Flow
        public string FlowSlow3 { get; set; }
        public string FlowSlow2 { get; set; }
        public string FlowFast { get; set; }
        public string FlowSlow1 { get; set; }
        public string FlowDecomp { get; set; }

        // Pressure
        public string PressureSlow3 { get; set; }
        public string PressureSlow2 { get; set; }
        public string PressureFast { get; set; }
        public string PressureSlow1 { get; set; }
        public string PressureDecomp { get; set; }

        // Position
        public string PositionSlow3 { get; set; }
        public string PositionSlow2 { get; set; }
        public string PositionFast { get; set; }
        public string PositionSlow1 { get; set; }
        public string PositionDecomp { get; set; }

        // Time
        public string TimeSlow3 { get; set; }
        public string TimeSlow2 { get; set; }
        public string TimeFast { get; set; }
        public string TimeSlow1 { get; set; }
        public string TimeDecomp { get; set; }

        // Speed
        public string SpeedSlow3 { get; set; }
        public string SpeedSlow2 { get; set; }
        public string SpeedFast { get; set; }
        public string SpeedSlow1 { get; set; }
        public string SpeedDecomp { get; set; }

        // Actual Stage Time
        public string ActStageTimeSlow3 { get; set; }
        public string ActStageTimeSlow2 { get; set; }
        public string ActStageTimeFast { get; set; }
        public string ActStageTimeSlow1 { get; set; }
        public string ActStageTimeDecomp { get; set; }

        // Clamp & Set Mode
        public string ClampPosition { get; set; }
        public string SetModeFlow { get; set; }
        public string SetModePressure { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }

    public class Page5Model_Methods
    {
        private string FormatToDecimalString(object value)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                return "00.0"; // fallback for null or empty

            string raw = value.ToString().Trim();

            if (!int.TryParse(raw, out int number))
                return "00.0"; // fallback for invalid numbers

            string padded = number.ToString("D3"); // e.g., "35" → "035"
            return padded.Insert(padded.Length - 1, "."); // "035" → "03.5"
        }
    }
}
