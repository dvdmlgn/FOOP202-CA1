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
    }
}
