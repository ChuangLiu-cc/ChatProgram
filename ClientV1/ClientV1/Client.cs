/*
 * FILE NAME: Form1.cs
 * PROJECT NAME: PROG 2120 a Assginment 06 IPC
 * PROGRAMMER: Chuang Liu & Ben Lorantfy
 * FIRST VERSION: 30/10/2014
 * DESCRPTION: this is a client.cs file, includes some data members and methods to complement function of client
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

namespace ClientV1
{
    class Client
    {
        /*data members*/
        bool running = false;
        public TcpClient tcpClientObject;//receive and send data object

        public Thread receiveThread; //thread of receive data 
        StreamReader reader;
        public delegate void receiveDelegate(string receiveData);  //handle receive data event 

        public event receiveDelegate receiveEvent; // the event of receive event


        /*
         * METHOD NAME: SendConnectionToServer
         * RETURN VALUE: void
         * PARAMETERS: string ipAdress: local ip address; int portNumber: port number when connecting server
         * DESCRIPTION: this metod will let client connect with server with ip address and port number
         */
        public void SendConnectionToServer(string ipAdress, int portNumber) 
        {
            running = true;
            IPAddress ipAddress = IPAddress.Parse(ipAdress);

            tcpClientObject = new TcpClient();  //connect with client

            tcpClientObject.Connect(ipAddress, portNumber); //connecting

            receiveThread = new Thread(ReceiveData);  //start the thread of receive data
            receiveThread.Start();

        }
        
        /*
         * METHOD NAME: SendData
         * RETURN VALUE: void
         * PARAMETERS: string messsage: send user input message to server
         * DESCRIPTION: this method will send user input message to server 
         */
        public void SendData(string message) 
        {
            if (tcpClientObject == null)  //if no client object connected, just return
            {
                return;
            }
            NetworkStream netStream = this.tcpClientObject.GetStream(); //get a network data stream

            StreamWriter streamWriter = new StreamWriter(netStream);//save message data into StreamWriter for  transmit data
            
            streamWriter.WriteLine(message);  //write into stream
            streamWriter.Flush(); //avoid memory leak
            netStream.Flush();  //avoid memory leak
        }
        /*
         * 
         * 
         * Receiving data corresponding to the thread and triggering event
         * 
         */
        /*
         * METHOD NAME: ReceiveData
         * RETURN VALUE: void
         * PARAMETERS: void
         * DESCRIPTION: this method will receive message from server and display in client's listbox 
         */
        public void ReceiveData()  
        {
            while (running) 
            {
                if (tcpClientObject != null) {
                    NetworkStream stream = this.tcpClientObject.GetStream();

                    reader = new StreamReader(stream);

                    try {
                        string receiveData = reader.ReadLine();
                        receiveEvent(receiveData);  //triggering event
                    } catch (Exception ex) {
                        running = false;
                        receiveEvent(null);
                    }
                }
            }
        }

        /*
         * METHOD NAME: Disconnect
         * RETURN VALUE: void
         * PARAMETERS: void
         * DESCRIPTION: sets running flag to false, closes stream, and joins recieve thread
         */
        public void Disconnect() {
            reader = null;
            running = false;
        }
    }
}
