using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigInsight.Core.Models
{
    public class Page44Model
    {
        // Clamp Scale
        public string ClampCount { get; set; }
        public string ClampZero { get; set; }
        public string ClampSpan { get; set; }
        public string ClampMM { get; set; }

        // Screw Scale
        public string ScrewCount { get; set; }
        public string ScrewZero { get; set; }
        public string ScrewSpan { get; set; }
        public string ScrewMM { get; set; }

        // Ejector Scale
        public string EjectorCount { get; set; }
        public string EjectorZero { get; set; }
        public string EjectorSpan { get; set; }
        public string EjectorMM { get; set; }

        // Carriage Scale
        public string CarriageCount { get; set; }
        public string CarriageZero { get; set; }
        public string CarriageSpan { get; set; }
        public string CarriageMM { get; set; }

        // System PT
        public string SystemZero { get; set; }
        public string SystemSpan { get; set; }
        public string SystemBar { get; set; }

        // Zone Temperatures
        public string Zone1Count { get; set; }
        public string Zone1Zero { get; set; }
        public string Zone1Span { get; set; }
        public string Zone1Deg { get; set; }

        public string Zone2Count { get; set; }
        public string Zone2Zero { get; set; }
        public string Zone2Span { get; set; }
        public string Zone2Deg { get; set; }

        public string Zone3Count { get; set; }
        public string Zone3Zero { get; set; }
        public string Zone3Span { get; set; }
        public string Zone3Deg { get; set; }

        public string Zone4Count { get; set; }
        public string Zone4Zero { get; set; }
        public string Zone4Span { get; set; }
        public string Zone4Deg { get; set; }

        public string Zone5Count { get; set; }
        public string Zone5Zero { get; set; }
        public string Zone5Span { get; set; }
        public string Zone5Deg { get; set; }

        // Hydraulic Oil
        public string HydOilCount { get; set; }
        public string HydOilZero { get; set; }
        public string HydOilSpan { get; set; }
        public string HydOilDeg { get; set; }

        // Metadata
        public int DataId { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }

}
