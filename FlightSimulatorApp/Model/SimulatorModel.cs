using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulatorApp.Model
{
    public class SimulatorModel : ISimulatorModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Mutex mutex;
        private ITelnetClient client;
        private volatile Boolean stop;
        //airplane values:
        private double headingDeg = 0;
        private double verticalSpeed = 1;
        private double groundSpeed = 2;
        private double airspeed = 3;
        private double gpsAltitude = 4;
        private double roll = 5;
        private double pitch = 6;
        private double altimeterAltitude = 7;
        private double latitude = 32.873331;
        private double longitude = 34.006333;
        private string planePosition;
        //coresponding properties:
        public double Heading { 
            get { return this.headingDeg; }
            set 
            {
                headingDeg = value;
                NotifyPropertyChanged("Heading");
            }
        }
        public double VerticalSpeed { 
            get { return this.verticalSpeed; }
            set
            {
                verticalSpeed = value;
                NotifyPropertyChanged("VerticalSpeed");
            }
        }
        public double GroundSpeed { 
            get { return this.groundSpeed; }
            set
            {
                groundSpeed = value;
                NotifyPropertyChanged("GroundSpeed");
            }
        }
        public double Airspeed { 
            get { return this.airspeed; }
            set
            {
                airspeed = value;
                NotifyPropertyChanged("Airspeed");
            }
        }
        public double GpsAltitude {
            get { return this.gpsAltitude; }
            set
            {
                gpsAltitude = value;
                NotifyPropertyChanged("GpsAltitude");
            }
        }
        public double Roll { 
            get { return this.roll; }
            set
            {
                roll = value;
                NotifyPropertyChanged("Roll");
            }
        }
        public double Pitch { 
            get { return this.pitch; }
            set
            {
                pitch = value;
                NotifyPropertyChanged("Pitch");
            }
        }
        public double AltimeterAltitude { 
            get { return this.altimeterAltitude; }
            set
            {
                altimeterAltitude = value;
                NotifyPropertyChanged("AltimeterAltitude");
            }
        }
        public double Latitude { 
            get { return this.latitude; }
            set
            {
                latitude = value;
                NotifyPropertyChanged("Latitude");
            }
        }
        public double Longitude { 
            get { return this.longitude; }
            set
            {
                longitude = value;
                NotifyPropertyChanged("Longitude");
            }
        }

        public string PlanePosition
        {
            get { return this.planePosition; }
            set
            {
                planePosition = value;
                NotifyPropertyChanged("PlanePosition");
            }
        }

        public SimulatorModel(TelnetClient client)
        {
            this.client = client;
            this.stop = false;
            this.mutex = new Mutex();
            this.client.MyMutex = this.mutex;
        }

        public void Connect(string ip, int port)
        {
            this.client.Connect(ip, port);
        }

        public void Disconnect()
        {
            this.client.Disconnect();
        }

        public void Start()
        {
            new Thread(delegate ()
            {
                while (!stop)
                {
                    this.Heading = Double.Parse(this.client.Write("get /instrumentation/heading-indicator/indicated-heading-deg\n"));
                    this.VerticalSpeed = Double.Parse(this.client.Write("get /instrumentation/gps/indicated-vertical-speed\n"));
                    this.GroundSpeed = Double.Parse(this.client.Write("get /instrumentation/gps/indicated-ground-speed-kt\n"));
                    this.Airspeed = Double.Parse(this.client.Write("get /instrumentation/airspeed-indicator/indicated-speed-kt\n"));
                    this.GpsAltitude = Double.Parse(this.client.Write("get /instrumentation/gps/indicated-altitude-ft\n"));
                    this.Roll = Double.Parse(this.client.Write("get /instrumentation/attitude-indicator/internal-roll-deg\n"));
                    this.Pitch = Double.Parse(this.client.Write("get /instrumentation/attitude-indicator/internal-pitch-deg\n"));
                    this.AltimeterAltitude = Double.Parse(this.client.Write("get /instrumentation/altimeter/indicated-altitude-ft\n"));
                    this.Latitude = Double.Parse(this.client.Write("get /position/latitude-deg\n"));
                    this.Longitude = Double.Parse(this.client.Write("get /position/longitude-deg\n"));
                    this.PlanePosition = this.Latitude.ToString() + ", " + this.Longitude.ToString();
                }
            }).Start();
        }

        public void NotifyPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
