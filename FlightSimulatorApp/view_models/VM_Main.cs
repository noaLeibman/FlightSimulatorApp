using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulatorApp.Model;
using System.ComponentModel;


namespace FlightSimulatorApp.view_models
{
    public class VM_Main : INotifyPropertyChanged
    {
        public VM_Map map;
        public VM_ControlPanel cp;
        public VM_JoystickControl steers;
        private ISimulatorModel model;
        public VM_Main(ISimulatorModel model)
        {
            this.model = model;
            this.map = new VM_Map();
            this.map.SetModel(model);
            this.cp = new VM_ControlPanel();
            this.cp.SetModel(model);
            this.steers = new VM_JoystickControl();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}