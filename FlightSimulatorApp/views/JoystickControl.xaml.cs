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
using FlightSimulatorApp.view_models;

namespace FlightSimulatorApp.views
{
    /// <summary>
    /// Interaction logic for JoystickControl.xaml
    /// </summary>
    public partial class JoystickControl : UserControl
    {

        public JoystickControl()
        {
            InitializeComponent();
           
          
        }
        private double rudder;

        private double Rudder
        {
            get
            {
                return rudder;

            }
            set
            {
                rudder = value;
                (Application.Current as App).ViewModel.steers.VM_Rudder = value;
            }
        }
        
    }
}
