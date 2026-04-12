using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigInsight.Core.Models
{

    public class Page10Model
    {
        public int DataId { get; set; }

        public string PresentStage { get; set; }
        public string StageTime { get; set; }

        public string CoreSelection { get; set; }
        public string CoreSequence { get; set; }

        public string ONDelayCoreIn { get; set; }
        public string ONDelayCoreOut { get; set; }

        public string OperationBasedOn { get; set; }

        public string FlowCoreIn { get; set; }
        public string FlowCoreOut { get; set; }

        public string SolDuringInjection { get; set; }

        public string PressureCoreIn { get; set; }
        public string PressureCoreOut { get; set; }

        public string InSolHold { get; set; }

        public string PositionCoreIn { get; set; }
        public string PositionCoreOut { get; set; }

        public string OutSolHold { get; set; }

        public string TimeCoreIn { get; set; }
        public string TimeCoreOut { get; set; }

        public string InDigitalOutput { get; set; }
        public string OutDigitalOutput { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }


}
