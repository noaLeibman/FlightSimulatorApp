using System;
using System.ComponentModel;
using FlightSimulatorApp.Model;


namespace FlightSimulatorApp.view_models
{
    public class VM_Map : INotifyPropertyChanged
    {
        private ISimulatorModel model;
        public VM_Map()
        {
            this.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                this.update(e.PropertyName);
            };
        }
        public double VM_Latitude 
        { 
            get { return this.model.Latitude; }
        }
        public double VM_Longitude
        {
            get { return this.model.Longitude; } 
        }
        public string PlanePosition 
        { 
            get 
            {
                string position = this.VM_Latitude.ToString() + ", " + this.VM_Longitude.ToString();
                Console.WriteLine(position);
                return position; 
            }
        }

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

        private void update(string name)
        {
            if (name == "Latitude")
            {
               
            }
        }
    }
}
