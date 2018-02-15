﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CarApplication
{
    public class Vehicle
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public DateTime Year { get; set; }
        public Brushes Colour { get; set; }
        public double Mileage { get; set; }
        public string Description { get; set; }
        // image property
    }
}
