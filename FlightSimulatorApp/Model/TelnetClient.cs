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
            this.client.ReceiveTimeout = (10000);

        }
        public string Write(string command)
        {
            string answer = string.Empty;
            try
            {
                MyMutex.WaitOne();
                Byte[] data = System.Text.Encoding.ASCII.GetBytes(command);
                stream.Write(data, 0, data.Length);
                answer = Read();
                MyMutex.ReleaseMutex();
            }
            catch (Exception e)
            {
                MyMutex.ReleaseMutex();
                throw (e);            }
            return answer;
        }
        public string Read()
        {
            String responseData = String.Empty;
            try
            {
                MyMutex.WaitOne();
                Byte[] data = new Byte[256];
                Int32 bytes = stream.Read(data, 0, data.Length);        
                responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
                MyMutex.ReleaseMutex();
            }
            catch (Exception e)
            {
                MyMutex.ReleaseMutex();
                throw (e);
            }
            
                return responseData;
        }
        public void Disconnect()
        {
            stream.Close();
            client.Close();
        }
    }
}
