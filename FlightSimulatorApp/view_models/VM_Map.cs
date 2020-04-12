using System;
using System.ComponentModel;
using FlightSimulatorApp.Model;
using Microsoft.Maps.MapControl.WPF;


namespace FlightSimulatorApp.view_models
{
    public class VM_Map : INotifyPropertyChanged
    {

  
        public double VM_Latitude

        { get 

            {
                return this.model.Latitude ; }
        }


        public double VM_Longitude
        { 
            get 
            { 

                return this.model.Longitude; } 
        }
        private Location VM_planeposition;
        public Location VM_PlanePosition
        {
            set
            {
                VM_planeposition = value;
            }
            get
            {
                Console.WriteLine(VM_planeposition);
                return VM_planeposition;

            }
        }

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
