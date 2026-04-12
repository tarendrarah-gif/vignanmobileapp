using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigInsight.Core.Models
{
    public class Page29Model
    {
        public int DataId { get; set; }
        // Mold related times
        public string MoldCloseSet { get; set; }
        public string MoldCloseActual { get; set; }

        public string MoldSafetySet { get; set; }
        public string MoldSafetyActual { get; set; }

        public string MoldLockingSet { get; set; }
        public string MoldLockingActual { get; set; }

        public string PreInjectSet { get; set; }
        public string PreInjectActual { get; set; }

        public string IntrugenSet { get; set; }
        public string IntrugenActual { get; set; }

        public string TotInjectSet { get; set; }
        public string TotInjectActual { get; set; }

        public string Inject1Set { get; set; }
        public string Inject1Actual { get; set; }

        public string Inject2Set { get; set; }
        public string Inject2Actual { get; set; }

        public string Inject3Set { get; set; }
        public string Inject3Actual { get; set; }

        public string Inject4Set { get; set; }
        public string Inject4Actual { get; set; }

        public string Inject5Set { get; set; }
        public string Inject5Actual { get; set; }

        public string MoldOpenHoldSet { get; set; }
        public string MoldOpenHoldActual { get; set; }

        // Hold On Times
        public string Hold1Set { get; set; }
        public string Hold1Actual { get; set; }

        public string Hold2Set { get; set; }
        public string Hold2Actual { get; set; }

        public string Hold3Set { get; set; }
        public string Hold3Actual { get; set; }

        public string Hold4Set { get; set; }
        public string Hold4Actual { get; set; }

        public string CoolingSet { get; set; }
        public string CoolingActual { get; set; }

        // Refill & Suckback
        public string Refill1Set { get; set; }
        public string Refill1Actual { get; set; }

        public string Refill2Set { get; set; }
        public string Refill2Actual { get; set; }

        public string Refill3Set { get; set; }
        public string Refill3Actual { get; set; }

        public string PreSuckbackSet { get; set; }
        public string PreSuckbackActual { get; set; }

        public string PostSuckbackSet { get; set; }
        public string PostSuckbackActual { get; set; }

        // Other times
        public string InitDecompSet { get; set; }
        public string InitDecompActual { get; set; }

        public string UnitFwd1Set { get; set; }
        public string UnitFwd1Actual { get; set; }

        public string UnitRet1Set { get; set; }
        public string UnitRet1Actual { get; set; }

        public string UnitRet2Set { get; set; }
        public string UnitRet2Actual { get; set; }

        public string FinDecomSet { get; set; }
        public string FinDecomActual { get; set; }

        public string TotCycleSet { get; set; }
        public string TotCycleActual { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }

}
