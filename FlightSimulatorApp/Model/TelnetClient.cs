using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace FlightSimulatorApp.Model
{
    public class TelnetClient : ITelnetClient
    {
        TcpClient client;
        NetworkStream stream;
        public void connect(string ip, int port)
        {
            this.client = new TcpClient(ip, port);
            this.stream = client.GetStream();
        }
        public void write(string command)
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(command);
            stream.Write(data, 0, data.Length);
        }
        public string read()
        {
            String responseData = String.Empty;
            Byte[] readdata = new Byte[256];
            Int32 bytes = stream.Read(readdata, 0, readdata.Length);
            responseData = System.Text.Encoding.ASCII.GetString(readdata, 0, bytes);
            string result = System.Text.Encoding.UTF8.GetString(readdata);
            return result;
        }
        public void disconnect()
        {
            stream.Close();
            client.Close();
        }
    }
}
