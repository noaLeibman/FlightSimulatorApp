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
            Console.WriteLine("starting");
            ISimulatorModel model = new SimulatorModel(new TelnetClient());
            ViewModel = new VM_Main(model);
            model.Connect("127.0.0.1", 5402);
            model.Start();
        }
    }
}
