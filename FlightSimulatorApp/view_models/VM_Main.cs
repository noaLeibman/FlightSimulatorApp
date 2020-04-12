using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSimulatorApp.Model;
using System.ComponentModel;


namespace FlightSimulatorApp.view_models
{
    public class VM_Main
    {
        public VM_Map map;
        public VM_ControlPanel cp;
        public VM_JoystickControl steers;
        public VM_Connect connect;
        public VM_ErrorLine errorLine;
        private ISimulatorModel model;
        public VM_Main(ISimulatorModel model)
        {
            this.model = model;
            this.map = new VM_Map();
            this.map.SetModel(model);
            this.cp = new VM_ControlPanel();
            this.cp.SetModel(model);
            this.steers = new VM_JoystickControl();
            this.steers.SetModel(model);
            this.connect = new VM_Connect();
            this.connect.SetModel(model);
            this.errorLine = new VM_ErrorLine();
            this.errorLine.SetModel(model);
        }

    }
}