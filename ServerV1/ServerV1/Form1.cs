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
        Server sever = new Server();
        public ServerForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)  //to start server
        {

            string ipAdd = "";
            if (this.txtPort.Text != "")
            {
                try
                {
                    sever.ConnectionEvent += new Server.Connect(serverObj_ConnectEvent); //get connection event

                    sever.ReceptionEvent += new Server.Receive(serverObj_ReceiveEvent);  //get reception data event

                    int temp = 0;
                    if (int.TryParse(txtPort.Text, out temp))  //avoid port textbox nothing to program error 
                    {

                        ipAdd = sever.Listen(Convert.ToInt32(txtPort.Text));   //start listen
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

        void serverObj_ReceiveEvent(string message)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    Server.Receive update = new Server.Receive(serverObj_ReceiveEvent);

                    this.Invoke(update, new object[] { message });
                }
                else
                {
                    this.lbMessage.Items.Add(message);



                    sever.SendMessage(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Event Method Failed：" + ex.Message);
                return;
            }

        }

        void serverObj_ConnectEvent()
        {
            try
            {
                if (this.InvokeRequired)
                {
                    Server.Connect update = new Server.Connect(serverObj_ConnectEvent);

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

        private void serverform_formclosed(object sender, FormClosedEventArgs e)
        {
            //Close background processes
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            sever.listenObject.Stop();
            this.Close();
        }

       
    }
}
