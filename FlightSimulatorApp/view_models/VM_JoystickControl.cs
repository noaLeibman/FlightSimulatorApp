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
                if (!model.IsStop)
                {
                    VM_rudder = value;
                    try
                    {
                        model.Write("set /controls/flight/rudder " + VM_rudder.ToString() + "\n");
                    }
                    catch (Exception e)
                    {
                        if (e.Message == "")
                        {

                        }
                    }
                    //function of model to send to server
                }
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
                if (!model.IsStop)
                {
                    VM_elevator = value;
                    try
                    {
                        model.Write("set /controls/flight/elevator " + VM_elevator.ToString() + "\n");
                    }
                    catch (Exception e)
                    {
                        if (e.Message == "")
                        {

                        }
                    }
                }
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
                if (!model.IsStop)
                {
                    try
                    {
                        model.Write("set /controls/engines/current-engine/throttle " + VM_throttle.ToString() + "\n");
                    }
                    catch (Exception e) {
                        if (e.Message == "")
                        {

                        }
                    }
                }
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
                if (!model.IsStop)
                {
                    VM_aileron = value;
                    try
                    {
                        model.Write("set /controls/flight/aileron " + VM_aileron.ToString() + "\n");
                    }
                    catch (Exception e) {
                        if (e.Message == "")
                        {

                        }
                    }
                    //function of model to send to server
                }
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