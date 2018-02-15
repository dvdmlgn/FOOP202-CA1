using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApplication
{
    public enum bikeType
    {
        Scooter,
        TrailBike,
        Sports,
        Commuter,
        Tourer
    }

    public class Bike : Vehicle
    {
        public bikeType Type { get; set; }
    }
}
