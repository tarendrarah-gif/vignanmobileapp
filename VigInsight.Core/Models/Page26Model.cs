using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigInsight.Core.Models
{
    public class Page26Model
    {
        public int DataId { get; set; }

        public string AutoDieLockingSelection { get; set; }
        public string AdjustBy { get; set; }

        // Forward/Retract
        public string AdjustTime { get; set; }
        public string StandStillTime { get; set; }
        public string FlowMovement { get; set; }
        public string FlowCounting { get; set; }
        public string PressureMovement { get; set; }
        public string PressureCounting { get; set; }
        public string NumberOfTrials { get; set; }

        // Locking parameters
        public string RequiredLockingPressure { get; set; }
        public string ExecutedTrials { get; set; }
        public string RequiredPulseCount { get; set; }
        public string DirectionOfRotation { get; set; }
        public string ActualPulseCount { get; set; }
        public string MachineLockingFactor { get; set; }
        public string PresentTrialCount { get; set; }
        public string ActualClampPressure { get; set; }
        public string ActualClampPosition { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }

}
