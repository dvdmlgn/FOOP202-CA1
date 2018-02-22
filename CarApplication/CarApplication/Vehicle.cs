using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CarApplication
{
    public enum VehicleType
    {
        Car,
        Bike,
        Van
    }

    public abstract class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public DateTime Year { get; set; }
        public Brushes Colour { get; set; }
        public double Mileage { get; set; }
        public string Description { get; set; }
        public ImageSource Image { get; set; }
        public double Engine { get; set; }


        public override string ToString()
        {
            return Make + ", " + Model + "\n" + string.Format("{0:C}", Price) + ", " + Mileage + " miles";
        }
    }
}
