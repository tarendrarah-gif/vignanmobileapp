using System;

namespace VigInsight.Core.Models
{
    public class Page2Model
    {
        public int DataId { get; set; }

        public string MoldClose  { get; set; }
        public string CoresIn    { get; set; }
        public string UnitFwd    { get; set; }
        public string Intrugen   { get; set; }
        public string Injection  { get; set; }
        public string HoldOn     { get; set; }
        public string Refill     { get; set; }
        public string Suckback   { get; set; }
        public string UnitRet    { get; set; }
        public string Cooling    { get; set; }
        public string MoldOpen   { get; set; }
        public string CoresOut   { get; set; }
        public string EjectorFwd { get; set; }
        public string EjectorRet { get; set; }
        public string CycleDelay { get; set; }
        public string TotCycTime { get; set; }

        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
