using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApplication
{
    public enum wheelbase
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
        Unlisted
    }

    class Van
    {
        public wheelbase WheelBase { get; set; }
        public vanType Type { get; set; }

    }
}
