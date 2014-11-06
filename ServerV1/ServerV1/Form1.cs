/*
 * FILE NAME: Form1.cs
 * PROJECT NAME: PROG 2120 a Assginment 06 IPC
 * PROGRAMMER: Chuang Liu & Ben Lorantfy
 * FIRST VERSION: 30/10/2014
 * DESCRPTION: This is a cs file of winForm. It can handle event and use some control within server
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Net;

namespace ServerV1
{
    public partial class ServerForm : Form
    {
        /*data member*/
        Server server = new Server();  //delcare a server object
        public ServerForm()
        {
            InitializeComponent();
        }
        /*
         * METHOD NAME: btnConnect_Click
         * RETURN VALUE: void
         * PARAMETERS: object sender, EventArgs e
         * DESCRIPTION: click connect button can connect with server
         */
        private void btnConnect_Click(object sender, EventArgs e)  //to start server
        {

            string ipAdd = "";
            if (this.txtPort.Text != "")
            {
                try
                {
                    server.ConnectionEvent += new Server.Connect(serverObject_ConnectEvent); //get connection event

                    server.ReceptionEvent += new Server.Receive(serverObject_ReceiveEvent);  //get reception data event

                    int temp = 0;
                    if (int.TryParse(txtPort.Text, out temp))  //avoid port textbox nothing to program error 
                    {

                        ipAdd = server.Listen(Convert.ToInt32(txtPort.Text));   //start listen
                    }

                    this.lbMessage.Items.Add("Server Started");
                    this.lbMessage.Items.Add("IP Address: " + ipAdd);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Loading Failed：" + ex.Message);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please enter your Port address...");
            }

        }
        /*
         * METHOD NAME: serverObj_ReceiveEvent
         * RETURN VALUE: void
         * PARAMETERS: string: message
         * DESCRIPTION: this method can access control and handle recevive data event with delegate
         */
        public void serverObject_ReceiveEvent(string message)
        {
            try
            {
                if (this.InvokeRequired)  //access control by InvokeRequired and thread Synchronous
                {
                    Server.Receive update = new Server.Receive(serverObject_ReceiveEvent);

                    this.Invoke(update, new object[] { message });
                }
                else
                {
                    this.lbMessage.Items.Add(message);
                    int visibleItems = lbMessage.ClientSize.Height / lbMessage.ItemHeight;// auto move down line content
                    lbMessage.TopIndex = Math.Max(lbMessage.Items.Count - visibleItems + 1, 0);

                    server.SendMessage(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Event Method Failed：" + ex.Message);
                return;
            }

        }
        /*
         * METHOD NAME: serverObj_ConnectEvent
         * RETURN VALUE: void
         * PARAMETERS: void
         * DESCRIPTION: this mehtod can let server object to handle connect event
         */
        public void serverObject_ConnectEvent()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    Server.Connect update = new Server.Connect(serverObject_ConnectEvent);

                    this.Invoke(update);
                }

                else
                {
                    this.lbMessage.Items.Add("Connect Success!");
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Event Failed: " + ex.Message);
                return;
            }
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e) {
            server.Shutdown();
        }

    }
}
