using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigInsight.Core.Models
{
    public class Page34Model
    {
        public string LubricationFlag { get; set; }
        public string LubricationSelection { get; set; } // e.g., OpenLoop, Grease, etc.
        public string LubricationMode { get; set; } // e.g., Shots, Timer

        // Interval Time
        public string LubIntervalTimeSet { get; set; }
        public string LubIntervalTimeRem { get; set; }

        // Interval Shots
        public string LubIntervalShotsSet { get; set; }
        public string LubIntervalShotsRem { get; set; }

        // Lubrication On Time
        public string LubOnTimeSet { get; set; }
        public string LubOnTimeRem { get; set; }

        // Repeat Cycles
        public string LubRepeatCycleSet { get; set; }
        public string LubRepeatCycleRem { get; set; }

        // Feedback Timeout
        public string LubFeedbackTimeoutSet { get; set; }
        public string LubFeedbackTimeoutRem { get; set; }

        // Minimum Off Time
        public string LubMinOffTimeSet { get; set; }
        public string LubMinOffTimeRem { get; set; }

        // Metadata
        public int DataId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }

}
