using System;
using System.Windows;
using FlightSimulatorApp.view_models;
using FlightSimulatorApp.Model;

namespace FlightSimulatorApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public VM_Main ViewModel { get; internal set; }
        private void Application_Startup(Object sender, StartupEventArgs e)
        {
            ISimulatorModel model = new SimulatorModel(new TelnetClient());
            ViewModel = new VM_Main(model);
        }
    }
}
