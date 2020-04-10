using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulatorApp.Model;
using FlightSimulatorApp.views;


namespace FlightSimulatorApp.view_models
{
    public class VM_JoystickControl : INotifyPropertyChanged
    {
        private ISimulatorModel model;
        public event PropertyChangedEventHandler PropertyChanged;

        private double VM_rudder;
        public double VM_Rudder
        {
            get
            {
                return VM_rudder;
            }
            set
            {
                VM_rudder = value;
                //function of model to send to server
            }
        }

 


        private void ThrottleChangedEvent(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {

        }
        public void SetModel(ISimulatorModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
        public void NotifyPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
    
  
}