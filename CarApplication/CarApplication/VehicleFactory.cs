using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CarApplication
{
    public static class VehicleFactory
    {
        private static Random random = new Random();

        public static ObservableCollection<Vehicle> ProductionLine(int unitsToMake)
        {
            ObservableCollection<Vehicle> vehicles = new ObservableCollection<Vehicle>();

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
            BitmapImage bitmap = new BitmapImage();
            ImageBrush imageBrush = new ImageBrush();

            switch (type)
            {
                case VehicleType.Car:
                    // we don't cast to type 'Car' because every new vehicle instance
                    // will a 'Car' be default

                    vehicle.Make = MainWindow.carsBase[random.Next(0, 3)].Make;
                    vehicle.Model = MainWindow.carsBase[random.Next(0, 3)].Models[random.Next(0, 2)];

                    vehicle.Mileage = random.Next(5000, 89000);
                    vehicle.Price = random.Next(8000, 45000);

                    bitmap = new BitmapImage(MainWindow.VehicleImages[random.Next(0, 4)]);

                    imageBrush = new ImageBrush
                    {
                        ImageSource = bitmap
                    };

                    vehicle.Image = imageBrush.ImageSource;

                    break;

                case VehicleType.Bike:
                    vehicle = new Bike();

                    vehicle.Make = MainWindow.bikesBase[random.Next(0, 2)].Make;
                    vehicle.Model = MainWindow.bikesBase[random.Next(0, 2)].Models[random.Next(0, 2)];

                    vehicle.Mileage = random.Next(5000, 89000);
                    vehicle.Price = random.Next(8000, 45000);

                    bitmap = new BitmapImage(MainWindow.VehicleImages[random.Next(0, 4)]);

                    imageBrush = new ImageBrush
                    {
                        ImageSource = bitmap
                    };

                    vehicle.Image = imageBrush.ImageSource;

                    break;

                case VehicleType.Van:
                    vehicle = new Van();

                    vehicle.Make = MainWindow.carsBase[random.Next(0, 2)].Make;
                    vehicle.Model = MainWindow.carsBase[random.Next(0, 2)].Models[random.Next(0, 2)];

                    vehicle.Mileage = random.Next(5000, 89000);
                    vehicle.Price = random.Next(8000, 45000);

                    bitmap = new BitmapImage(MainWindow.VehicleImages[random.Next(0, 4)]);

                    imageBrush = new ImageBrush
                    {
                        ImageSource = bitmap
                    };

                    vehicle.Image = imageBrush.ImageSource;

                    break;
            }
        }
    }



}
