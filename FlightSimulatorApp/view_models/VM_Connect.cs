using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace FlightSimulatorApp.view_models
{
    public class VM_Connect : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string VM_IP { get; set; }
        string VM_Port { get; set; }
    }
}
