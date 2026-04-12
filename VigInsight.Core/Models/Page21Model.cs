using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigInsight.Core.Models
{
    public class Page21Model
    {
        public int DataId { get; set; }

        // Zone 1
        public string SetTempZone1 { get; set; }
        public string LowAlarmZone1 { get; set; }
        public string HighAlarmZone1 { get; set; }
        public string DutyZone1 { get; set; }
        public string OvershootZone1 { get; set; }
        public string StatusZone1 { get; set; }
        public string ActualTempZone1 { get; set; }

        // Zone 2
        public string SetTempZone2 { get; set; }
        public string LowAlarmZone2 { get; set; }
        public string HighAlarmZone2 { get; set; }
        public string DutyZone2 { get; set; }
        public string OvershootZone2 { get; set; }
        public string StatusZone2 { get; set; }
        public string ActualTempZone2 { get; set; }

        // Zone 3
        public string SetTempZone3 { get; set; }
        public string LowAlarmZone3 { get; set; }
        public string HighAlarmZone3 { get; set; }
        public string DutyZone3 { get; set; }
        public string OvershootZone3 { get; set; }
        public string StatusZone3 { get; set; }
        public string ActualTempZone3 { get; set; }

        // Zone 4
        public string SetTempZone4 { get; set; }
        public string LowAlarmZone4 { get; set; }
        public string HighAlarmZone4 { get; set; }
        public string DutyZone4 { get; set; }
        public string OvershootZone4 { get; set; }
        public string StatusZone4 { get; set; }
        public string ActualTempZone4 { get; set; }

        // Zone 5
        public string SetTempZone5 { get; set; }
        public string LowAlarmZone5 { get; set; }
        public string HighAlarmZone5 { get; set; }
        public string DutyZone5 { get; set; }
        public string OvershootZone5 { get; set; }
        public string StatusZone5 { get; set; }
        public string ActualTempZone5 { get; set; }

        // Hyd. Oil
        public string SetTempHydOil { get; set; }
        public string LowAlarmHydOil { get; set; }
        public string HighAlarmHydOil { get; set; }
        public string DutyHydOil { get; set; }
        public string OvershootHydOil { get; set; }
        public string StatusHydOil { get; set; }
        public string ActualTempHydOil { get; set; }

        // Nozzle
        public string SetTempNozzle { get; set; }
        public string LowAlarmNozzle { get; set; }
        public string HighAlarmNozzle { get; set; }
        public string DutyNozzle { get; set; }
        public string OvershootNozzle { get; set; }
        public string StatusNozzle { get; set; }
        public string ActualTempNozzle { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }

}
