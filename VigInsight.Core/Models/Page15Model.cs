using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigInsight.Core.Models
{
    public class Page15Model
    {
        public int DataId { get; set; }

        public string Mode { get; set; }
        public string TotalInjTimeSet { get; set; }
        public string Elapsed { get; set; }
        public string Remaining { get; set; }

        // Flow
        public string FlowStage5 { get; set; }
        public string FlowStage4 { get; set; }
        public string FlowStage3 { get; set; }
        public string FlowStage2 { get; set; }
        public string FlowStage1 { get; set; }
        public string FlowIntrugen { get; set; }
        public string FlowPreInject { get; set; }

        // Pressure
        public string PressureStage5 { get; set; }
        public string PressureStage4 { get; set; }
        public string PressureStage3 { get; set; }
        public string PressureStage2 { get; set; }
        public string PressureStage1 { get; set; }
        public string PressureIntrugen { get; set; }
        public string PressurePreInject { get; set; }

        // Position
        public string PositionStage5 { get; set; }
        public string PositionStage4 { get; set; }
        public string PositionStage3 { get; set; }
        public string PositionStage2 { get; set; }
        public string PositionStage1 { get; set; }
        public string PositionIntrugen { get; set; }
        public string PositionPreInject { get; set; }

        // Time
        public string TimeStage5 { get; set; }
        public string TimeStage4 { get; set; }
        public string TimeStage3 { get; set; }
        public string TimeStage2 { get; set; }
        public string TimeStage1 { get; set; }
        public string TimeIntrugen { get; set; }
        public string TimePreInject { get; set; }

        // Pump
        public string PumpStage5 { get; set; }
        public string PumpStage4 { get; set; }
        public string PumpStage3 { get; set; }
        public string PumpStage2 { get; set; }
        public string PumpStage1 { get; set; }
        public string PumpIntrugen { get; set; }
        public string PumpPreInject { get; set; }

        // Speed
        public string SpeedStage5 { get; set; }
        public string SpeedStage4 { get; set; }
        public string SpeedStage3 { get; set; }
        public string SpeedStage2 { get; set; }
        public string SpeedStage1 { get; set; }
        public string SpeedIntrugen { get; set; }
        public string SpeedPreInject { get; set; }

        // Actual Stage Times
        public string ActStageTimeStage5 { get; set; }
        public string ActStageTimeStage4 { get; set; }
        public string ActStageTimeStage3 { get; set; }
        public string ActStageTimeStage2 { get; set; }
        public string ActStageTimeStage1 { get; set; }
        public string ActStageTimeIntrugen { get; set; }
        public string ActStageTimePreInject { get; set; }

        // Bottom section
        public string ScrewPosition { get; set; }
        public string SwitchoverPosition { get; set; }
        public string InjectionBoostStage { get; set; }
        public string Solenoid { get; set; }
        public string InjectionSetTime { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }



}
