using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulatorApp.Model
{
    class SimulatorModel : ISimulatorModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ITelnetClient client;
        private volatile Boolean stop;
        //airplane values:
        private double headingDeg;
        private double verticalSpeed;
        private double groundSpeed;
        private double airspeed;
        private double gpsAltitude;
        private double roll;
        private double pitch;
        private double altimeterAltitude;
        private double latitude;
        private double longitude;
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
        }

        public void connect(string ip, int port)
        {
            this.client.connect(ip, port);
        }

        public void disconnect()
        {
            this.client.disconnect();
        }

        public void start()
        {
            new Thread(delegate ()
            {
                while (!stop)
                {
                    this.client.write("get /instrumentation/heading-indicator/indicated-heading-deg\n");
                    this.client.write("get /instrumentation/gps/indicated-vertical-speed\n");
                    this.client.write("get /instrumentation/gps/indicated-ground-speed-kt\n");
                    this.client.write("get /instrumentation/airspeed-indicator/indicated-speed-kt\n");
                    this.client.write("get /instrumentation/gps/indicated-altitude-ft\n");
                    this.client.write("get /instrumentation/attitude-indicator/internal-roll-deg\n");
                    this.client.write("get /instrumentation/attitude-indicator/internal-pitch-deg\n");
                    this.client.write("get /instrumentation/altimeter/indicated-altitude-ft\n");
                    this.client.write("get /position/latitude-deg\n");
                    this.client.write("get /position/longitude-deg\n");
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
