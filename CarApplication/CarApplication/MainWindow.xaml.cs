using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;

namespace CarApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public enum SortBy
        {
            Make,
            Price,
            Mileage
        }

        public VehicleBase fordCars = new VehicleBase();
        public VehicleBase BmwCars = new VehicleBase();
        public VehicleBase RenaultCars = new VehicleBase();

        public static List<VehicleBase> carsBase = new List<VehicleBase>();

        public VehicleBase HarleyDavidsonBikes = new VehicleBase();
        public VehicleBase SuzukiBikes = new VehicleBase();

        public static List<VehicleBase> bikesBase = new List<VehicleBase>();

        public static ObservableCollection<Vehicle> VehicleMaster = new ObservableCollection<Vehicle>();

        public static ObservableCollection<Vehicle> VehicleCatalogue = new ObservableCollection<Vehicle>();



        //public string filepath = "";


        //public string VehicleDBjson = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            comboBoxSortBy.ItemsSource = Enum.GetValues(typeof(SortBy));
            comboBoxSortBy.SelectedIndex = 0;
            // Enum.GetValues(typeof(EffectStyle)).Cast<EffectStyle>();

            //filepath = Environment.CurrentDirectory;
            //filepath = filepath.Substring(0, filepath.Length - 9);

            //testLabel.Content = "success";

            //VehicleDBjson = File.ReadAllText(filepath + "models-json.json");

            //testLabel.Content = VehicleDBjson;

            fordCars.Make = "Ford";
            fordCars.Models = new List<string>();
            fordCars.Models.Add("Focus");
            fordCars.Models.Add("Fiesta");

            BmwCars.Make = "BMW";
            BmwCars.Models = new List<string>();
            BmwCars.Models.Add("1 Series");
            BmwCars.Models.Add("2 Series");

            RenaultCars.Make = "Renault";
            RenaultCars.Models = new List<string>();
            RenaultCars.Models.Add("Megane");
            RenaultCars.Models.Add("Clio");

            carsBase.Add(fordCars);
            carsBase.Add(BmwCars);
            carsBase.Add(RenaultCars);


            HarleyDavidsonBikes.Make = "Harley-Davidson";
            HarleyDavidsonBikes.Models = new List<string>();
            HarleyDavidsonBikes.Models.Add("Roadster");
            HarleyDavidsonBikes.Models.Add("Low Rider");

            SuzukiBikes.Make = "Suzuki";
            SuzukiBikes.Models = new List<string>();
            SuzukiBikes.Models.Add("V-Strom 1000");
            SuzukiBikes.Models.Add("Intruder M800");

            bikesBase.Add(HarleyDavidsonBikes);
            bikesBase.Add(SuzukiBikes);

            VehicleMaster = VehicleFactory.ProductionLine(117);

            VehicleCatalogue = VehicleMaster;

            listBoxCatalogue.ItemsSource = VehicleCatalogue;


        }

        private void buttonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            buttonOpenMenu.Visibility = Visibility.Collapsed;
            buttonCloseMenu.Visibility = Visibility.Visible;
        }

        private void buttonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            buttonOpenMenu.Visibility = Visibility.Visible;
            buttonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void listViewNavbar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = listViewNavbar.SelectedItem as ListViewItem;

            if (selectedItem != null)
            {
                switch (selectedItem.Name)
                {
                    case "ItemCatalogue":
                        Catalogue.Visibility = Visibility.Visible;
                        Edit.Visibility = Visibility.Collapsed;
                        Settings.Visibility = Visibility.Collapsed;


                        iconCatalogue.Foreground = Brushes.Wheat;
                        textBlockCatalogue.Foreground = Brushes.Wheat;

                        iconEdit.Foreground = Brushes.White;
                        textBlockEdit.Foreground = Brushes.White;

                        iconSettings.Foreground = Brushes.White;
                        textBlockSettings.Foreground = Brushes.White;
                        break;

                    case "ItemEdit":
                        Catalogue.Visibility = Visibility.Collapsed;
                        Edit.Visibility = Visibility.Visible;
                        Settings.Visibility = Visibility.Collapsed;


                        iconCatalogue.Foreground = Brushes.White;
                        textBlockCatalogue.Foreground = Brushes.White;

                        iconEdit.Foreground = Brushes.Wheat;
                        textBlockEdit.Foreground = Brushes.Wheat;

                        iconSettings.Foreground = Brushes.White;
                        textBlockSettings.Foreground = Brushes.White;
                        break;

                    case "ItemSettings":
                        Catalogue.Visibility = Visibility.Collapsed;
                        Edit.Visibility = Visibility.Collapsed;
                        Settings.Visibility = Visibility.Visible;


                        iconCatalogue.Foreground = Brushes.White;
                        textBlockCatalogue.Foreground = Brushes.White;

                        iconEdit.Foreground = Brushes.White;
                        textBlockEdit.Foreground = Brushes.White;

                        iconSettings.Foreground = Brushes.Wheat;
                        textBlockSettings.Foreground = Brushes.Wheat;
                        break;
                }

            }
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            gridAdd.Visibility = Visibility.Visible;
            gridEdit.Visibility = Visibility.Collapsed;
            gridDelete.Visibility = Visibility.Collapsed;

            buttonAdd.Foreground = Brushes.Wheat;
            buttonEdit.Foreground = Brushes.White;
            buttonDelete.Foreground = Brushes.White;
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            gridAdd.Visibility = Visibility.Collapsed;
            gridEdit.Visibility = Visibility.Visible;
            gridDelete.Visibility = Visibility.Collapsed;

            buttonAdd.Foreground = Brushes.White;
            buttonEdit.Foreground = Brushes.Wheat;
            buttonDelete.Foreground = Brushes.White;
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            gridAdd.Visibility = Visibility.Collapsed;
            gridEdit.Visibility = Visibility.Collapsed;
            gridDelete.Visibility = Visibility.Visible;

            buttonAdd.Foreground = Brushes.White;
            buttonEdit.Foreground = Brushes.White;
            buttonDelete.Foreground = Brushes.Wheat;
        }

        private void comboBoxSortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //var selectedItem = comboBoxSortBy.SelectedItem as string;

            switch (comboBoxSortBy.SelectedIndex)
            {
                case 0:
                    listBoxCatalogue.ItemsSource = VehicleCatalogue.OrderBy(x => x.Make);
                    break;


                case 1:
                    listBoxCatalogue.ItemsSource = VehicleCatalogue.OrderBy(x => x.Price);
                    break;


                case 2:
                    listBoxCatalogue.ItemsSource = VehicleCatalogue.OrderBy(x => x.Mileage);
                    break;
            }
        }

        private void radioButtonAll_Click(object sender, RoutedEventArgs e)
        {
            VehicleCatalogue = VehicleMaster;

            listBoxCatalogue.ItemsSource = VehicleCatalogue;
        }

        private void radioButtonCars_Click(object sender, RoutedEventArgs e)
        {
            //VehicleCatalogue = VehicleMaster;

            ObservableCollection<Vehicle> cars = new ObservableCollection<Vehicle>();

            foreach(Vehicle vehicle in VehicleMaster)
            {
                if(vehicle is Car)
                {
                    cars.Add(vehicle);
                }

            }

            VehicleCatalogue = cars;

            listBoxCatalogue.ItemsSource = VehicleCatalogue;
        }

        private void radioButtonBikes_Click(object sender, RoutedEventArgs e)
        {
            //VehicleCatalogue = VehicleMaster;

            ObservableCollection<Vehicle> bikes = new ObservableCollection<Vehicle>();

            foreach (Vehicle vehicle in VehicleMaster)
            {
                if (vehicle is Bike)
                {
                    bikes.Add(vehicle);
                }

            }

            VehicleCatalogue = bikes;


            listBoxCatalogue.ItemsSource = VehicleCatalogue;
        }

        private void radioButtonVans_Click(object sender, RoutedEventArgs e)
        {
            //VehicleCatalogue = VehicleMaster;

            ObservableCollection<Vehicle> vans = new ObservableCollection<Vehicle>();

            foreach (Vehicle vehicle in VehicleMaster)
            {
                if (vehicle is Van)
                {
                    vans.Add(vehicle);
                }

            }

            VehicleCatalogue = vans;

            listBoxCatalogue.ItemsSource = VehicleCatalogue;

        }
    }
}
