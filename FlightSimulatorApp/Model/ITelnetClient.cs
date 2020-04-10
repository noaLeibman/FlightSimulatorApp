using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace FlightSimulatorApp.Model
{
    public interface ITelnetClient
    {
        Mutex MyMutex { get; set; }
        void Connect(string ip, int port);
        string Write(string command);
        string Read();
        void Disconnect();
    }
}
