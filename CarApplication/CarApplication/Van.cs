using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApplication
{
    public enum wheelBase
    {
        Short,
        Medium,
        Long,
        Unlisted
    }

    public enum vanType
    {
        CombiVan,
        Dropside,
        PanelVan,
        Pickup,
        Tipper,
        Unlisted,
    }

    public class Van : Vehicle
    {
        public wheelBase WheelBase { get; set; }
        public vanType Type { get; set; }
    }
}
