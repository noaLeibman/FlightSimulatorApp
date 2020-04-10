using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using FlightSimulatorApp.Model;

namespace FlightSimulatorApp.view_models
{
    public class VM_ControlPanel : INotifyPropertyChanged

    {
        public string VM_Heading { get { return this.model.Heading.ToString(); } }
        public string VM_VerticalSpeed { get { return this.model.VerticalSpeed.ToString(); } }
        public string VM_GroundSpeed { get { return this.model.GroundSpeed.ToString(); } }
        public string VM_Airspeed { get { return this.model.Airspeed.ToString(); } }
        public string VM_GpsAltitude { get { return this.model.GpsAltitude.ToString(); } }
        public string VM_Roll { get { return this.model.Roll.ToString(); } }
        public string VM_Pitch { get { return this.model.Pitch.ToString(); } }
        public string VM_AltimeterAltitude { get { return this.model.AltimeterAltitude.ToString(); } }

        private ISimulatorModel model;
        public void SetModel(ISimulatorModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
