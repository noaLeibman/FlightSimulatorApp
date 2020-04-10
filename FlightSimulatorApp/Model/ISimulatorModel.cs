using System.ComponentModel;

namespace FlightSimulatorApp.Model
{
    public interface ISimulatorModel : INotifyPropertyChanged
    {
        void Connect(string ip, int port);
        void Disconnect();
        void Start();
        double Heading { get; set; }
        double VerticalSpeed { get; set; }
        double GroundSpeed { get; set; }
        double Airspeed { get; set; }
        double GpsAltitude { get; set; }
        double Roll { get; set; }
        double Pitch { get; set; }
        double AltimeterAltitude { get; set; }
        double Latitude { get; set; }
        double Longitude { get; set; }
    }
}
