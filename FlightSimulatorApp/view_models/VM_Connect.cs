using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using FlightSimulatorApp.Model;
using System.Configuration;

namespace FlightSimulatorApp.view_models
{
    public class VM_Connect
    {
        private ISimulatorModel model;
        private string ip = (ConfigurationManager.AppSettings["defIP"]);
        private int port = Int32.Parse(ConfigurationManager.AppSettings["defPort"]);
        public string VM_IP
        {
            get { return this.ip; }
            set
            {
                this.ip = value;
            }
        }
        public int VM_Port
        {
            get { return this.port; }
            set
            {
                this.port = value;
            }
        }
        public void SetModel(ISimulatorModel model)
        {
            this.model = model;
        }

        public void Connect()
        {
            this.model.Connect(this.VM_IP, this.VM_Port);
        }
    }
}
