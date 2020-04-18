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
            (Application.Current as App).ViewModel.connect.VM_IP = e.Text;
        }

        private void PortInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                (Application.Current as App).ViewModel.connect.VM_Port = Int32.Parse(e.Text);
            }
            catch (Exception exp)
            {
                if (exp.Message == "")
                {

                }
            }
        }

        private void ClickButton(object sender, RoutedEventArgs e)
        {
            if (userIP.Text != "" && userPort.Text != "")
            {
                (Application.Current as App).ViewModel.connect.VM_IP = userIP.Text;
                (Application.Current as App).ViewModel.connect.VM_Port = Int32.Parse(userPort.Text);
            }
            (Application.Current as App).ViewModel.connect.Connect();
        }
    }
}
