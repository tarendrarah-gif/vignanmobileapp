using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigInsight.Core.Models
{
    public class Page11Model
    {
        public int DataId { get; set; }

        // Top Row Info
        public string PresentStage { get; set; }
        public string StageTime { get; set; }

        // Core-2 Selection and Sequence
        public string CoreSelection { get; set; }
        public string CoreSequence { get; set; }

        // Core IN/OUT Timings
        public string ONDelayCoreIn { get; set; }
        public string ONDelayCoreOut { get; set; }

        // Core Operation Info
        public string OperationBasedOn { get; set; }
        public string SolDuringInjection { get; set; }
        public string InSolHold { get; set; }
        public string OutSolHold { get; set; }

        // Flow
        public string FlowCoreIn { get; set; }
        public string FlowCoreOut { get; set; }

        // Pressure
        public string PressureCoreIn { get; set; }
        public string PressureCoreOut { get; set; }

        // Position
        public string PositionCoreIn { get; set; }
        public string PositionCoreOut { get; set; }

        // Time
        public string TimeCoreIn { get; set; }
        public string TimeCoreOut { get; set; }

        // Digital Outputs
        public string InDigitalOutput { get; set; }
        public string OutDigitalOutput { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }

}
