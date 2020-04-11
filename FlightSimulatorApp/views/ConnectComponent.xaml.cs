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
    /// Interaction logic for ConnectComponent.xaml
    /// </summary>
    public partial class ConnectComponent : UserControl
    {
        public ConnectComponent()
        {
            InitializeComponent();
        }

        private void IPInput(object sender, TextCompositionEventArgs e)
        {
            //connect.VM_IP = e.text;
        }

        private void PortInput(object sender, TextCompositionEventArgs e)
        {
            //connect.VM_Port = e.text;
        }
    }
}
