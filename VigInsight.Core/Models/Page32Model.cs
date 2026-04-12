using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigInsight.Core.Models
{
    public class Page32Model
    {
        public string MotorStatus { get; set; }
        public string SwitchedOnBy { get; set; }
        public string StarterType { get; set; }
        public string StarDeltaDelaySec { get; set; }
        public string StarDeltaDelayMin { get; set; }
        public string OnDelaySec { get; set; }
        public string OnDelayMin { get; set; }
        public string HandOperation { get; set; }
        public string PowerSaving { get; set; }
        public string SwitchOnMotorTime { get; set; }
        public string StarterOutputK1 { get; set; }
        public string StarterOutputK2 { get; set; }

        // Common fields
        public int DataId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }

}
