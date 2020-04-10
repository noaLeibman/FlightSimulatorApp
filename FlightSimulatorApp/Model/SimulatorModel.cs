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
        //coresponding properties:
        public double HeadingDeg { 
            get { return this.headingDeg; }
            set 
            {
                headingDeg = value;
                NotifyPropertyChanged("headingDeg");
            }
        }
        public double VerticalSpeed { 
            get { return this.verticalSpeed; }
            set
            {
                headingDeg = value;
                NotifyPropertyChanged("verticalSpeed");
            }
        }
        public double GroundSpeed { 
            get { return this.groundSpeed; }
            set
            {
                headingDeg = value;
                NotifyPropertyChanged("groungSpeed");
            }
        }
        public double Airspeed { 
            get { return this.airspeed; }
            set
            {
                headingDeg = value;
                NotifyPropertyChanged("airspeed");
            }
        }
        public double GpsAltitude {
            get { return this.gpsAltitude; }
            set
            {
                headingDeg = value;
                NotifyPropertyChanged("gpsAltitude");
            }
        }
        public double Roll { 
            get { return this.roll; }
            set
            {
                headingDeg = value;
                NotifyPropertyChanged("roll");
            }
        }
        public double Pitch { 
            get { return this.pitch; }
            set
            {
                headingDeg = value;
                NotifyPropertyChanged("pitch");
            }
        }
        public double AltimeterAltitude { 
            get { return this.altimeterAltitude; }
            set
            {
                headingDeg = value;
                NotifyPropertyChanged("altimeterAltitude");
            }
        }
        public double Latitude { 
            get { return this.latitude; }
            set
            {
                headingDeg = value;
                NotifyPropertyChanged("latitude");
            }
        }
        public double Longitude { 
            get { return this.longitude; }
            set
            {
                headingDeg = value;
                NotifyPropertyChanged("longitude");
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
                    this.headingDeg = Double.Parse(this.client.Write("get /instrumentation/heading-indicator/indicated-heading-deg\n"));
                    this.verticalSpeed = Double.Parse(this.client.Write("get /instrumentation/gps/indicated-vertical-speed\n"));
                    this.groundSpeed = Double.Parse(this.client.Write("get /instrumentation/gps/indicated-ground-speed-kt\n"));
                    this.airspeed = Double.Parse(this.client.Write("get /instrumentation/airspeed-indicator/indicated-speed-kt\n"));
                    this.gpsAltitude = Double.Parse(this.client.Write("get /instrumentation/gps/indicated-altitude-ft\n"));
                    this.roll = Double.Parse(this.client.Write("get /instrumentation/attitude-indicator/internal-roll-deg\n"));
                    this.pitch = Double.Parse(this.client.Write("get /instrumentation/attitude-indicator/internal-pitch-deg\n"));
                    this.altimeterAltitude = Double.Parse(this.client.Write("get /instrumentation/altimeter/indicated-altitude-ft\n"));
                    this.latitude = Double.Parse(this.client.Write("get /position/latitude-deg\n"));
                    this.longitude = Double.Parse(this.client.Write("get /position/longitude-deg\n"));
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
