using System.ComponentModel;
using FlightSimulatorApp.Model;


namespace FlightSimulatorApp.view_models
{
    public class VM_Map : INotifyPropertyChanged
    {
        private ISimulatorModel model;
        public double VM_Latitude 
        { 
            get { return this.model.Latitude; }
        }
        public double VM_Longitute
        {
            get { return this.model.Longitude; } 
        }
        public string PlanePosition 
        { 
            get { return this.VM_Latitude.ToString() + ", " + this.VM_Latitude.ToString(); }
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
    }
}
