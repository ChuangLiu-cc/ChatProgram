/*
 * FILE NAME: Server.cs
 * PROJECT NAME: PROG 2120 a Assginment 06 IPC
 * PROGRAMMER: Chuang Liu & Ben Lorantfy
 * FIRST VERSION: 30/10/2014
 * DESCRPTION: This is a server class, can listen clients, receive data from clients and send data to all of clients.
 * 
 */
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
        /*data memeber*/
        public TcpListener listenObject;   //Listener object
        public Dictionary<string, TcpClient> clientList = new Dictionary<string, TcpClient>(); //save client list and initializtion
        public List<Thread> clientThreads = new List<Thread>(); // stores all the client threads\
        public List<StreamReader> clientReaders = new List<StreamReader>();

        private Thread listenThread;  //listener thread

        public delegate void Connect();  //method of handling event after connect succeed

        public event Connect ConnectionEvent;  //connection event

        public delegate void Receive(string message);  //method of handling event after receive data

        public event Receive ReceptionEvent;  //receive data event


        public bool listening = true;
        public Thread receiveThread;

        /*
         * METHOD NAME: Listen
         * RETURN VALUE: string : local Ip address
         * PARAMETERS: int portNumber: port number 
         * DESCRIPTION: listen method and start listening thread
         */
        public string Listen(int portNumber)
        {
           
            IPAddress localip = IPAddress.Parse(GetLocalIp());  //get local IP

            this.listenObject = new TcpListener(localip, portNumber); //listen object

            this.listenThread = new Thread(ListenClient);       //thread of listen client 

            listenThread.Start();  //start this thread
            
         
            return GetLocalIp();   //return local IP to display on screen of server

        }


        /*
          * METHOD NAME: ListenClient
          * RETURN VALUE: void
          * PARAMETERS: void
          * DESCRIPTION: listen thread corresponding method. And send message to all clients after listening to the message
          */
        public void ListenClient()
        {
            while (listening)   //this loop for multiple client to connect with server
            {
                listenObject.Start();  //start listen request after thread start 

                TcpClient acceptClientObject;
                try {
                    acceptClientObject = listenObject.AcceptTcpClient();
                } catch(SocketException exception){
                    acceptClientObject = null;
                }

                if (acceptClientObject != null) {
                    this.ConnectionEvent();  //trigger connection event

                    receiveThread = new Thread(ReceiveMessage);  //the thread to process the received data
                    clientThreads.Add(receiveThread);           // Stores the thread in the clientThreads list

                    string connectTime = DateTime.Now.ToString();

                    receiveThread.Name = connectTime;  //use connect time to set thread name

                    this.clientList.Add(connectTime, acceptClientObject);  //add client to client list

                    receiveThread.Start();             //can get data when received connection
                }

            }
            listenObject.Stop();
        }


        /*
          * METHOD NAME: SendMessage
          * RETURN VALUE: string message: send this message to all of clients
          * PARAMETERS: void
          * DESCRIPTION: Send message to all of clients
          */
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

        /*
          * METHOD NAME: ReceiveMessage
          * RETURN VALUE: void
          * PARAMETERS: void
          * DESCRIPTION: receive message from each client
          */
        public void ReceiveMessage()
        {
            //all TcpClient corresponds to a thread and receive data from client. Through thread name, can find client
            while (listening)
            {
                
                //when TcpClient a client, assignment a thread to correspond
                NetworkStream netStream = clientList[Thread.CurrentThread.Name].GetStream();

                StreamReader streamReader = new StreamReader(netStream);

                string message = null;

                clientReaders.Add(streamReader);
                try {
                    message = streamReader.ReadLine(); //read message
                } catch (IOException exception) {
                    streamReader = null;
                }

                if (streamReader != null) {
                    clientReaders.Remove(streamReader);
                }


                if (message != null) {
                    this.ReceptionEvent(message);   //trigger this event after receive datam
                }
            }
        }

        
        /*
          * METHOD NAME: GetLocalIp
          * RETURN VALUE: string
          * PARAMETERS: void
          * DESCRIPTION: get local ip address
          */
        static string GetLocalIp()  
        {  
            IPHostEntry host;
            string localIP = "?";
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                }
            }
            return localIP;
        }

        /*
          * METHOD NAME: Shutdown
          * RETURN VALUE: void
          * PARAMETERS: void
          * DESCRIPTION: sets listening flag to false and joins all recieve threads
          */
        public void Shutdown() {
            listening = false;

            if (listenObject != null) {
                listenObject.Stop();
            }
            
            if (listenThread != null) {
                listenThread.Join();
            }

            foreach (StreamReader reader in clientReaders) {
                if (reader != null) {
                    reader.Close();
                }
            }

            foreach (Thread thread in clientThreads) {
                if (thread != null) {
                    thread.Join();
                }
            }
        }
    }
}
