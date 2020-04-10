using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;

namespace FlightSimulatorApp.Model
{
    public class TelnetClient : ITelnetClient
    {
        TcpClient client;
        NetworkStream stream;

        public Mutex MyMutex { get; set; }

        public void SetMutex(Mutex mutex)
        {
            this.MyMutex = mutex;
        }
        public void Connect(string ip, int port)
        {
            this.client = new TcpClient(ip, port);
            this.stream = client.GetStream();
            this.stream.ReadTimeout = 10000;
        }
        public string Write(string command)
        {
            MyMutex.WaitOne();
            Console.WriteLine(command);
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(command);
            stream.Write(data, 0, data.Length);
            string answer = Read();
            Console.WriteLine(answer);
            MyMutex.ReleaseMutex();
            return answer;
        }
        public string Read()
        {
            String responseData = String.Empty;
            Byte[] readdata = new Byte[256];
            Int32 bytes = stream.Read(readdata, 0, readdata.Length);
            responseData = System.Text.Encoding.ASCII.GetString(readdata, 0, bytes);
            string result = System.Text.Encoding.ASCII.GetString(readdata);
            return result;
        }
        public void Disconnect()
        {
            stream.Close();
            client.Close();
        }
    }
}
