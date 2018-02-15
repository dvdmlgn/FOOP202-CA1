using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApplication
{
    public enum bodyType
    {
        Convertible,
        Hatchback,
        Coupé,
        Estate,
        MPV,
        SUV,
        Unlisted
    }
    public class Car
    {
        public bodyType BodyType { get; set; }
    }
}
