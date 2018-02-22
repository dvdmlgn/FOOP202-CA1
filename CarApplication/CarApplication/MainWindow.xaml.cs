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

        public static List<Uri> VehicleImages = new List<Uri>();


        public string filepath = "";


        //public string VehicleDBjson = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            comboBoxSortBy.ItemsSource = Enum.GetValues(typeof(SortBy));
            comboBoxSortBy.SelectedIndex = 0;

            comboBoxTypes.ItemsSource = Enum.GetValues(typeof(VehicleType));
            comboBoxTypes.SelectedIndex = 0;
            //Enum.GetValues(typeof(EffectStyle)).Cast<EffectStyle>();

            filepath = Environment.CurrentDirectory;
            filepath = filepath.Substring(0, filepath.Length - 9);

            string imageFilePath = filepath + "/Assets/";


            VehicleImages.Add(new Uri(imageFilePath + "FordFocus.jpg", UriKind.RelativeOrAbsolute));
            VehicleImages.Add(new Uri(imageFilePath + "FordFiesta.png", UriKind.RelativeOrAbsolute));
            VehicleImages.Add(new Uri(imageFilePath + "Bmw1Series.jpg", UriKind.RelativeOrAbsolute));
            VehicleImages.Add(new Uri(imageFilePath + "Bmw2Series.png", UriKind.RelativeOrAbsolute));

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

            VehicleMaster = VehicleFactory.ProductionLine(1117);

            VehicleCatalogue = VehicleMaster;

            listBoxCatalogue.ItemsSource = VehicleCatalogue;



            listBoxEdit.ItemsSource = VehicleMaster;

            listBoxDelete.ItemsSource = VehicleMaster;


            //vehicleImage.Source

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

            gridEditDetails.Visibility = Visibility.Collapsed;

            buttonAdd.Foreground = Brushes.Wheat;
            buttonEdit.Foreground = Brushes.White;
            buttonDelete.Foreground = Brushes.White;

            buttonAdd.Background = null;
            buttonEdit.Background = (Brush)FindResource("MaterialDesignDivider");
            buttonDelete.Background = (Brush)FindResource("MaterialDesignDivider");

            // Background = "{DynamicResource MaterialDesignDivider}"
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            gridAdd.Visibility = Visibility.Collapsed;
            gridEdit.Visibility = Visibility.Visible;
            gridDelete.Visibility = Visibility.Collapsed;

            gridEditDetails.Visibility = Visibility.Collapsed;

            buttonAdd.Foreground = Brushes.White;
            buttonEdit.Foreground = Brushes.Wheat;
            buttonDelete.Foreground = Brushes.White;

            buttonAdd.Background = (Brush)FindResource("MaterialDesignDivider");
            buttonEdit.Background = null;
            buttonDelete.Background = (Brush)FindResource("MaterialDesignDivider");
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            gridAdd.Visibility = Visibility.Collapsed;
            gridEdit.Visibility = Visibility.Collapsed;
            gridDelete.Visibility = Visibility.Visible;

            gridEditDetails.Visibility = Visibility.Collapsed;

            buttonAdd.Foreground = Brushes.White;
            buttonEdit.Foreground = Brushes.White;
            buttonDelete.Foreground = Brushes.Wheat;

            buttonAdd.Background = (Brush)FindResource("MaterialDesignDivider");
            buttonEdit.Background = (Brush)FindResource("MaterialDesignDivider");
            buttonDelete.Background = null;
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

            foreach (Vehicle vehicle in VehicleMaster)
            {
                if (vehicle is Car)
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

        private void listBoxCatalogue_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBoxCatalogue.SelectedItem != null)
            {
                card.Visibility = Visibility.Visible;

                var selectedItem = listBoxCatalogue.SelectedItem as Vehicle;

                labelMake.Content = selectedItem.Make;
                labelModel.Content = selectedItem.Model;
                labelPrice.Content = string.Format("{0:C}", selectedItem.Price);
                labelMileage.Content = string.Format("{0:n0}", selectedItem.Mileage);
                labelYear.Content = selectedItem.Year.Year;


                vehicleImage.Source = selectedItem.Image;

            }
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            //VehicleMaster.Add(new Car());

            Vehicle newVehicle = new Car();

            switch (comboBoxTypes.SelectedIndex)
            {
                case 0:

                    break;


                case 1:
                    newVehicle = new Bike();

                    break;


                case 2:
                    newVehicle = new Van();

                    break;
            }

            newVehicle.Make = textBoxMake.Text;
            newVehicle.Model = textBoxModel.Text;
            newVehicle.Price = decimal.Parse(textBoxPrice.Text);
            newVehicle.Mileage = 50000;

            VehicleMaster.Add(newVehicle);

            listBoxCatalogue.ItemsSource = VehicleMaster;

        }

        private void buttonDeleteSelected_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxDelete.SelectedItem != null)
            {
                int hashCode = listBoxDelete.SelectedItem.GetHashCode();

                // Finds the selected item in the Vehicle Master Collection
                // by comparing each items hashCode,
                // and then deletes it
                for (int i = 0; i < VehicleMaster.Count; i++)
                {
                    if (VehicleMaster[i].GetHashCode() == hashCode)
                    {
                        VehicleMaster.RemoveAt(i);
                    }
                }
            }
        }

        private void buttonEditDetails_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxEdit.SelectedItem != null)
            {
                var selectedItem = listBoxEdit.SelectedItem as Vehicle;

                gridEdit.Visibility = Visibility.Collapsed;
                gridEditDetails.Visibility = Visibility.Visible;

                textBoxEditMake.Text = selectedItem.Make;
                textBoxEditModel.Text = selectedItem.Model;
                textBoxEditPrice.Text = selectedItem.Price.ToString();
                //textBoxEditYear.Text = selectedItem.Year;

            }
        }

        private void buttonEditSave_Click(object sender, RoutedEventArgs e)
        {
            #region Properties
            // ----------------------------------------------------------------------------------------------------------------------------------------------------

            var selectedItem = listBoxEdit.SelectedItem as Vehicle;
            int hashCode = listBoxEdit.SelectedItem.GetHashCode();

            int itemIndex = -1;

            // ----------------------------------------------------------------------------------------------------------------------------------------------------
            #endregion


            #region find selected item in Vehicle Master Collection
            // ----------------------------------------------------------------------------------------------------------------------------------------------------

            // Finds the selected item in the Vehicle Master Collection
            // by comparing each items hashCode
            for (int i = 0; i < VehicleMaster.Count; i++)
            {
                if (VehicleMaster[i].GetHashCode() == hashCode)
                {
                    itemIndex = i;
                    break;
                }
            }

            // ----------------------------------------------------------------------------------------------------------------------------------------------------
            #endregion


            #region update vehicle details
            // ----------------------------------------------------------------------------------------------------------------------------------------------------

            VehicleMaster[itemIndex].Make = textBoxEditMake.Text;
            VehicleMaster[itemIndex].Model = textBoxEditModel.Text;
            VehicleMaster[itemIndex].Price = decimal.Parse(textBoxEditPrice.Text);

            // ----------------------------------------------------------------------------------------------------------------------------------------------------
            #endregion


            #region update listBoxes
            // ----------------------------------------------------------------------------------------------------------------------------------------------------

            listBoxEdit.ItemsSource = VehicleMaster;

            // ----------------------------------------------------------------------------------------------------------------------------------------------------
            #endregion
        }

        private void ButtonSettingsSave_Click(object sender, RoutedEventArgs e)
        {
            string saveJson = JsonConvert.SerializeObject(VehicleMaster);

            string jsonFilepath = filepath + "vehicleMaster.json";

            using (StreamWriter sw = new StreamWriter(jsonFilepath))
            {
                string json = JsonConvert.SerializeObject(VehicleMaster, Formatting.Indented);
                sw.Write(json);
            }

           // File.WriteAllText(saveJson, jsonFilepath);
        }

        private void buttonSettingsLoad_Click(object sender, RoutedEventArgs e)
        {
            if( File.Exists(filepath + "vehicleMaster.json") )
            VehicleMaster = JsonConvert.DeserializeObject< ObservableCollection<Vehicle> >(filepath + "vehicleMaster.json");
        }
    }
}
