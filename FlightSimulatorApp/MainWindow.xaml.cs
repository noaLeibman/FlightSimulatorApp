using FlightSimulatorApp.view_models;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FlightSimulatorApp.views;

namespace FlightSimulatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VM_Main viewModel = (Application.Current as App).ViewModel;
        public MainWindow()
        {
            VM_JoystickControl steers = viewModel.steers;
            VM_Map map = viewModel.map;
            VM_ControlPanel cp = viewModel.cp;
            InitializeComponent();
            DataContext = new
            {
                steers,
                map,
                cp
            };
        }
    }
}
