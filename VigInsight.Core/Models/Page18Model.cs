using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigInsight.Core.Models
{
    public class Page18Model
    {
        public int DataId { get; set; }

        public string Model { get; set; }
        public string CoolingTimeSet { get; set; }
        public string Remaining { get; set; }

        // Selection
        public string SelectionIntrugen { get; set; }
        public string SelectionPreSuckback { get; set; }
        public string SelectionRefill1 { get; set; }
        public string SelectionRefill2 { get; set; }
        public string SelectionRefill3 { get; set; }
        public string SelectionPostSuckback { get; set; }

        // Flow
        public string FlowIntrugen { get; set; }
        public string FlowPreSuckback { get; set; }
        public string FlowRefill1 { get; set; }
        public string FlowRefill2 { get; set; }
        public string FlowRefill3 { get; set; }
        public string FlowPostSuckback { get; set; }

        // Sys Pre
        public string SysPreIntrugen { get; set; }
        public string SysPrePreSuckback { get; set; }
        public string SysPreRefill1 { get; set; }
        public string SysPreRefill2 { get; set; }
        public string SysPreRefill3 { get; set; }
        public string SysPrePostSuckback { get; set; }

        // Back Pre
        public string BackPreIntrugen { get; set; }
        public string BackPrePreSuckback { get; set; }
        public string BackPreRefill1 { get; set; }
        public string BackPreRefill2 { get; set; }
        public string BackPreRefill3 { get; set; }
        public string BackPrePostSuckback { get; set; }

        // Position
        public string PositionIntrugen { get; set; }
        public string PositionPreSuckback { get; set; }
        public string PositionRefill1 { get; set; }
        public string PositionRefill2 { get; set; }
        public string PositionRefill3 { get; set; }
        public string PositionPostSuckback { get; set; }

        // Time
        public string TimeIntrugen { get; set; }
        public string TimePreSuckback { get; set; }
        public string TimeRefill1 { get; set; }
        public string TimeRefill2 { get; set; }
        public string TimeRefill3 { get; set; }
        public string TimePostSuckback { get; set; }

        // Screw RPM
        public string ScrewRPMIntrugen { get; set; }
        public string ScrewRPMPreSuckback { get; set; }
        public string ScrewRPMRefill1 { get; set; }
        public string ScrewRPMRefill2 { get; set; }
        public string ScrewRPMRefill3 { get; set; }
        public string ScrewRPMPostSuckback { get; set; }

        // Speed
        public string SpeedIntrugen { get; set; }
        public string SpeedPreSuckback { get; set; }
        public string SpeedRefill1 { get; set; }
        public string SpeedRefill2 { get; set; }
        public string SpeedRefill3 { get; set; }
        public string SpeedPostSuckback { get; set; }

        // Act Stage Time
        public string ActStageTimeIntrugen { get; set; }
        public string ActStageTimePreSuckback { get; set; }
        public string ActStageTimeRefill1 { get; set; }
        public string ActStageTimeRefill2 { get; set; }
        public string ActStageTimeRefill3 { get; set; }
        public string ActStageTimePostSuckback { get; set; }

        // Screw Info
        public string ScrewPosition { get; set; }
        public string RefillingBoostSelection { get; set; }
        public string Solenoid { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }

}
