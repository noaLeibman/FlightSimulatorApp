using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FlightSimulatorApp.view_models;
using Microsoft.Maps.MapControl.WPF;
using System.IO;

namespace FlightSimulatorApp.Model
{
    public class SimulatorModel : ISimulatorModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Mutex mutex;
        public ITelnetClient client;
        public volatile Boolean stop = true;
        private volatile Boolean connected = false;
        //airplane values:
        private double headingDeg = 0;
        private double verticalSpeed = 0;
        private double groundSpeed = 0;
        private double airspeed = 0;
        private double gpsAltitude = 0;
        private double roll = 0;
        private double pitch = 0;
        private double altimeterAltitude = 0;
        private double latitude = 32.8733;
        private double longitude = 34.0063;
        private string message = "no messages for now";
        //coresponding properties:

        public bool IsStop
        {
            get
            { return this.stop; }
            set
            {
                this.stop = value;
            }
        }
        public double Heading
        {
            get
            {

                return this.headingDeg;
            }
            set
            {
                headingDeg = value;
                NotifyPropertyChanged("Heading");
            }
        }
        public double VerticalSpeed
        {
            get { return this.verticalSpeed; }
            set
            {
                verticalSpeed = value;
                NotifyPropertyChanged("VerticalSpeed");
            }
        }
        public double GroundSpeed
        {
            get
            {
                return this.groundSpeed;
            }
            set
            {
                groundSpeed = value;
                NotifyPropertyChanged("GroundSpeed");
            }
        }
        public double Airspeed
        {
            get { return this.airspeed; }
            set
            {
                airspeed = value;
                NotifyPropertyChanged("Airspeed");
            }
        }
        public double GpsAltitude
        {
            get { return this.gpsAltitude; }
            set
            {
                gpsAltitude = value;
                NotifyPropertyChanged("GpsAltitude");
            }
        }
        public double Roll
        {
            get { return this.roll; }
            set
            {
                roll = value;
                NotifyPropertyChanged("Roll");
            }
        }
        public double Pitch
        {
            get { return this.pitch; }
            set
            {
                pitch = value;
                NotifyPropertyChanged("Pitch");
            }
        }
        public double AltimeterAltitude
        {
            get { return this.altimeterAltitude; }
            set
            {
                altimeterAltitude = value;
                NotifyPropertyChanged("AltimeterAltitude");
            }
        }
        public double Latitude
        {
            get
            {
                return this.latitude;
            }
            set
            {
                if (value > 83)
                {
                    value = 83;
                    this.Message = "Outerspace?! No! bad plane!";
                }
                else if (value < -80)
                {
                    value = -80;
                    this.Message = "Outerspace?! No! bad plane!";
                }
                latitude = value;
                NotifyPropertyChanged("PlanePosition");
            }
        }
        public double Longitude
        {
            get
            {
                return this.longitude;
            }
            set
            {
                if (value < -170)
                {
                    value = -170;
                    this.Message = "Outerspace?! No! bad plane!";
                }
                else if (value > 170)
                {
                    value = 170;
                    this.Message = "Outerspace?! No! bad plane!";
                }
                longitude = value;
                NotifyPropertyChanged("PlanePosition");
            }
        }
        public string Message
        {
            get { return this.message; }
            set
            {
                this.message = value;
                NotifyPropertyChanged("Message");
            }
        }
        public SimulatorModel(TelnetClient client)
        {
            this.client = client;
            this.mutex = new Mutex();
            this.client.MyMutex = this.mutex;
        }

        public void Connect(string ip, int port)
        {
            if (!connected)
            {
                try
                {
                    this.client.Connect(ip, port);
                    this.Message = "Connected!";
                    this.connected = true;
                    this.IsStop = false;
                    this.Start();
                }
                catch (Exception e)
                {
                    this.Message = e.Message;
                }
            }
        }
        public void Disconnect()
        {
            this.IsStop = true;
            this.client.Disconnect();
            this.connected = false;
        }
        public void Start()
        {
            new Thread(delegate ()
            {
                while (!IsStop)
                {
                    try
                    {
                        this.Latitude = Double.Parse(this.client.Write("get /position/latitude-deg\n"));
                        this.Longitude = Double.Parse(this.client.Write("get /position/longitude-deg\n"));
                        this.Heading = Double.Parse(this.client.Write("get /instrumentation/heading-indicator/indicated-heading-deg\n"));
                        this.VerticalSpeed = Double.Parse(this.client.Write("get /instrumentation/gps/indicated-vertical-speed\n"));
                        this.GroundSpeed = Double.Parse(this.client.Write("get /instrumentation/gps/indicated-ground-speed-kt\n"));
                        this.Airspeed = Double.Parse(this.client.Write("get /instrumentation/airspeed-indicator/indicated-speed-kt\n"));
                        this.GpsAltitude = Double.Parse(this.client.Write("get /instrumentation/gps/indicated-altitude-ft\n"));
                        this.Roll = Double.Parse(this.client.Write("get /instrumentation/attitude-indicator/internal-roll-deg\n"));
                        this.Pitch = Double.Parse(this.client.Write("get /instrumentation/attitude-indicator/internal-pitch-deg\n"));
                        this.AltimeterAltitude = Double.Parse(this.client.Write("get /instrumentation/altimeter/indicated-altitude-ft\n"));
                        Thread.Sleep(250);
                        this.AltimeterAltitude = Double.Parse("NaN");
                    }
                    catch (IOException exception)
                    {
                        if (exception.Message == "Unable to write data to the transport connection: An existing connection was forcibly closed by the remote host.")
                        {
                            this.Message = "Seems like server is down :(";
                            connected = false;

                        }
                        else
                        {
                            Console.WriteLine(exception.Message);

                            this.Message = "Timeout - Server not responding";
                        }
                        this.IsStop = true;
                    }
                    catch (Exception e)
                    {
                        if (e.Message == "Input string was not in a correct format.")
                        {
                            this.Message = "Server returned 'ERR'";
                        }
                        else
                        {
                            this.IsStop = true;
                            this.Message = "Seems like server is down:(";
                            this.connected = false;
                        }
                    }
                } 
            }).Start();
        }
        public void NotifyPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        public string Write(string command)
        {
            string str = null;
            if (connected)
            {
                str = client.Write(command);
                if (str == "ERR")
                {
                    this.Message = "Server returned 'ERR'";
                }
            }
            return str;
        }
    }
}