using System.ComponentModel;

namespace FlightSimulatorApp.Model
{
    interface ISimulatorModel : INotifyPropertyChanged
    {
        void connect(string ip, int port);
        void disconnect();
        void start();
    }
}
