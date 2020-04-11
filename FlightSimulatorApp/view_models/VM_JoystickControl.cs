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
                model.Write("set /controls/flight/rudder " + VM_rudder.ToString() + "\n");
              
                //function of model to send to server
            }
        }
        private double VM_elevator;
        public double VM_Elevator
        {
            get
            {
                return VM_elevator;
            }
            set
            {
                model.Write("set / controls / flight / elevator " + VM_elevator.ToString() + "\n"); 
                VM_elevator = value;
           
            }
        }
        private double VM_throttle;
        public double VM_Throttle
        {
            get
            {
                return VM_throttle;
            }
            set
            {
                VM_throttle = value;
                model.Write("set / controls / engines / current - engine / throttle " + VM_throttle.ToString() + "\n");
            }
        }
        private double VM_aileron;
        public double VM_Aileron
        {
            get
            {
                return VM_aileron;
            }
            set
            {
                VM_aileron = value;
                model.Write("set / controls / flight / aileron " + VM_aileron.ToString() + "\n");
                //function of model to send to server
            }
        }


        public void NotifyPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        public void SetModel(ISimulatorModel model)
        {
            this.model = model;

        }

    }
}