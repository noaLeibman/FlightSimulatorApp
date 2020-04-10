using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulatorApp.view_models
{
    public class VM_ControlPanel
    {
        public string VM_heading { get { return "8"; } }
        public string VM_verticalSpeed { get { return "309"; } }
        public string VM_groundSpeed { get { return "88"; } }
        public string VM_airspeed { get { return "44444"; } }
        public string VM_gpsAltitude { get { return "1234"; } }
        public string VM_roll { get { return "55"; } }
        public string VM_pitch { get { return "32"; } }
        public string VM_altimeterAltitude { get { return "35"; } }
        public VM_ControlPanel()
        {
        }

    }
}
