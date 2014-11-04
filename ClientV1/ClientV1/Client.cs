using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace ClientV1
{
    class Client
    {
        public TcpClient tcpClientObject;//receive and send data 

        private Thread receiveThread; //thread for receive data

        public delegate void receiveDelegate(string receiveData);

        public event receiveDelegate receiveEvent; 

        public void SendConnection(string ipAdress, int portNumber) 
        {
            IPAddress ipAddress = IPAddress.Parse(ipAdress);

            tcpClientObject = new TcpClient();

            tcpClientObject.Connect(ipAddress, portNumber);

            receiveThread = new Thread(Receiver); 
            receiveThread.Start();

        }

        public void Send(string message) 
        {
            if (tcpClientObject == null)
            {
                return;
            }
            NetworkStream netStream = this.tcpClientObject.GetStream();

            StreamWriter streamWriter = new StreamWriter(netStream);

            streamWriter.WriteLine(message);

            streamWriter.Flush(); 
            netStream.Flush();
        }

        private void Receiver()  
        {
            while (true) 
            {
                NetworkStream netStream = this.tcpClientObject.GetStream();

                StreamReader streamWriter = new StreamReader(netStream);

                string receivedata = streamWriter.ReadLine();

                receiveEvent(receivedata);
            }
        } 

    }
}
