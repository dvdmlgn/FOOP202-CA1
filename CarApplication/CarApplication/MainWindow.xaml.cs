using System;
using System.Collections.Generic;
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

namespace CarApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public string filepath = "";
        

        //public string VehicleDBjson = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            //filepath = Environment.CurrentDirectory;
            //filepath = filepath.Substring(0, filepath.Length - 9);

            //testLabel.Content = "success";

            //VehicleDBjson = File.ReadAllText(filepath + "models-json.json");

            //testLabel.Content = VehicleDBjson;
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

            if(selectedItem != null)
            {
                switch (selectedItem.Name)
                {
                    case "ItemCatalogue":
                        Catalogue.Visibility = Visibility.Visible;
                        Edit.Visibility      = Visibility.Collapsed;
                        Settings.Visibility  = Visibility.Collapsed;


                        iconCatalogue.Foreground = Brushes.Wheat;
                        textBlockCatalogue.Foreground = Brushes.Wheat;

                        iconEdit.Foreground = Brushes.White;
                        textBlockEdit.Foreground = Brushes.White;

                        iconSettings.Foreground = Brushes.White;
                        textBlockSettings.Foreground = Brushes.White;
                        break;

                    case "ItemEdit":
                        Catalogue.Visibility = Visibility.Collapsed;
                        Edit.Visibility      = Visibility.Visible;
                        Settings.Visibility  = Visibility.Collapsed;


                        iconCatalogue.Foreground = Brushes.White;
                        textBlockCatalogue.Foreground = Brushes.White;

                        iconEdit.Foreground = Brushes.Wheat;
                        textBlockEdit.Foreground = Brushes.Wheat;

                        iconSettings.Foreground = Brushes.White;
                        textBlockSettings.Foreground = Brushes.White;
                        break;

                    case "ItemSettings":
                        Catalogue.Visibility = Visibility.Collapsed;
                        Edit.Visibility      = Visibility.Collapsed;
                        Settings.Visibility  = Visibility.Visible;


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
            gridAdd.Visibility    = Visibility.Visible;
            gridEdit.Visibility   = Visibility.Collapsed;
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
    }
}
