using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarApplication
{
    public static class VehicleFactory
    {
        private static Random random = new Random();

        public static List<Vehicle> ProductionLine(int unitsToMake)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            for(int i = 0; i < unitsToMake; i++)
            {
                vehicles.Add( NewVehicle( (VehicleType)random.Next(0, 2) ) );  // the project brief specifies to use 3 different types of vehicles
            }

            return vehicles;
        }


        private static Vehicle NewVehicle(VehicleType type)
        {
            Vehicle vehicle = new Car();

            CastToVehicleType(ref vehicle, type);


            return vehicle;
        }

        private static void CastToVehicleType(ref Vehicle vehicle, VehicleType type)
        {
            switch (type)
            {
                case VehicleType.Car:
                    // we don't cast to type 'Car' because every new vehicle instance
                    // will a 'Car' be default

                    break;

                case VehicleType.Bike:
                    vehicle = vehicle as Bike;


                    break;

                case VehicleType.Van:
                    vehicle = vehicle as Van;

                    break;
            }
        }
    }



}
