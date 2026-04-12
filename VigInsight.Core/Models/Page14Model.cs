using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigInsight.Core.Models
{
    public class Page14Model
    {
        public int DataId { get; set; }

        // AE-1
        public string AE1Selection { get; set; }
        public string AE1StartPosition { get; set; }
        public string AE1OnDelay { get; set; }
        public string AE1SetStrokes { get; set; }
        public string AE1OnTime { get; set; }
        public string AE1OffTime { get; set; }
        public string AE1DigitalOutput { get; set; }
        public string AE1Operation { get; set; }
        public string AE1ActStageTime { get; set; }
        public string AE1StrokesExecuted { get; set; }
        public string AE1StrokesRemaining { get; set; }

        // AE-2
        public string AE2Selection { get; set; }
        public string AE2StartPosition { get; set; }
        public string AE2OnDelay { get; set; }
        public string AE2SetStrokes { get; set; }
        public string AE2OnTime { get; set; }
        public string AE2OffTime { get; set; }
        public string AE2DigitalOutput { get; set; }
        public string AE2Operation { get; set; }
        public string AE2ActStageTime { get; set; }
        public string AE2StrokesExecuted { get; set; }
        public string AE2StrokesRemaining { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }

}
