using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace ServerV1
{
    class Server
    {
        public TcpListener listenObject;   //Listener object
        public Dictionary<string, TcpClient> clientList = new Dictionary<string, TcpClient>(); //save client list and initializtion

        private Thread listenThread;  //listener thread

        public delegate void Connect();  //method of handling event after connect succeed

        public event Connect ConnectionEvent;  //connection event

        public delegate void Receive(string message);  //method of handling event after receive data

        public event Receive ReceptionEvent;  //receive data event


        /*listen method and start listening thread*/
        public string Listen(int portNumber)
        {
            IPAddress[] localIP = Dns.GetHostAddresses(Dns.GetHostName());  //get local IP

            this.listenObject = new TcpListener(localIP[1], portNumber); //listen object

            this.listenThread = new Thread(ListenClient);       //thread of listen client 

            listenThread.Start();  //start this thread
            
            return GetLocalIp();   //return local IP to display on screen of server

        }

        /*listen thread corresponding method. And send message to all clients after listening to the message*/
        public void ListenClient()
        {
            while (true)   //this loop for multiple client to connect with server
            {
                listenObject.Start();  //start listen request after thread.start() 

                TcpClient acceptClientObject = listenObject.AcceptTcpClient();           //     receive pending connection request, which is a blocking method

                this.ConnectionEvent();  //trigger connection event

                Thread receiveThread = new Thread(ReceiveMessage);  //the thread to process the received data

                string connectTime = DateTime.Now.ToString();

                receiveThread.Name = connectTime;  //use connect time to set thread name

                this.clientList.Add(connectTime, acceptClientObject);  //add client to client list

                receiveThread.Start();             //can get data when received connection
            }
        }

        /*Send message*/
        public void SendMessage(string message)
        {

            foreach (KeyValuePair<string, TcpClient> data in clientList)  //send data to all clents
            {

                if (data.Value == null || data.Value.Connected == false)
                {
                    clientList.Remove(data.Key);         //remove unconnection (maybe you can use better way)???
                    continue;
                }

                NetworkStream netStream = data.Value.GetStream();   //get net stream by using data of receive

                StreamWriter streamWriter = new StreamWriter(netStream);  //declare a streamwrite and associated with net stream
                streamWriter.WriteLine(message);          //output message 

                streamWriter.Flush();  //refresh data stream
                netStream.Flush();
            }

        }

        /*receive data*/
        public void ReceiveMessage()
        {
            //all TcpClient corresponds to a thread and receive data from client. Through thread name, can find client
            while (true)
            {
                //when TcpClient a client, assignment a thread to correspond
                NetworkStream netStream = clientList[Thread.CurrentThread.Name].GetStream();

                StreamReader streamReader = new StreamReader(netStream);

                string message = streamReader.ReadLine(); //read message

                this.ReceptionEvent(message);   //trigger this event after receive datam
            }
        }

        /*get local Ipv4 address*/
        static string GetLocalIp()  
        {  
            IPHostEntry IpEntry = Dns.GetHostEntry(Dns.GetHostName());
            string myip = IpEntry.AddressList[1].ToString();

            return myip;
        }

    }
}
