/*
 * FILE NAME: Form1.cs
 * PROJECT NAME: PROG 2120 a Assginment 06 IPC
 * PROGRAMMER: Chuang Liu & Ben Lorantfy
 * FIRST VERSION: 30/10/2014
 * DESCRPTION: This is a cs file of winForm. It can handle event and use some control wiitin a client
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

namespace ClientV1
{
    public partial class ClientForm : Form
    {

        private Client ClientObject = new Client();   //client object
        
        public ClientForm()
        {
            InitializeComponent();
        }
        /*
         * METHOD NAME: ClientForm_Load
         * RETURN VALUE: void
         * PARAMETERS: object sender, EventArgs e
         * DESCRIPTION: when form start, will handle this event
         */
        private void ClientForm_Load(object sender, EventArgs e)
        {
            btnSendMessage.Enabled = false; //can not send meassage if not connection
            this.AcceptButton = btnSendMessage;  //send message button as a accept button
        }
        
        /*
         * METHOD NAME: btnConnect_Click
         * RETURN VALUE: void
         * PARAMETERS: object sender, EventArgs e
         * DESCRIPTION: click connect button will handle this event
         */
        private void btnConnect_Click(object sender, EventArgs e)
        {
            string name = tbName.Text;
            string ipAddress = tbIPAddress.Text;
            string portNum = tbPort.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(ipAddress) || string.IsNullOrEmpty(portNum))
            {
                MessageBox.Show("Please completely enter your name and server IP address...");
                return;
            }

            try
            {

                ClientObject.SendConnectionToServer(ipAddress, Convert.ToInt32(portNum)); //connecting

                ClientObject.receiveEvent += new Client.receiveDelegate(ClientObject_receiveEvent);

                ClientObject.SendData(this.tbName.Text + " login succeed!");

                btnSendMessage.Enabled = true;
                btnConnect.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connecting Mistake:" + ex.Message);
                return;
            }
        }
        /*
         * METHOD NAME: ClientObj_receiveEvent
         * RETURN VALUE: void
         * PARAMETERS: string receiveData: receive data
         * DESCRIPTION: this method can access control and let client object handle receuve event with delegate
         */
        public void ClientObject_receiveEvent(string receiveData)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    Client.receiveDelegate update = new Client.receiveDelegate(ClientObject_receiveEvent);

                    this.Invoke(update, new object[] { receiveData });//send message to thread 
                }
                else
                {
                    if (receiveData == null) {
                        receiveData = "Disconnected from server";
                        ClientObject.Disconnect();
                        Application.Exit();
                    }

                    lbMessage.Items.Add(receiveData);//add data
                    int visibleItems = lbMessage.ClientSize.Height / lbMessage.ItemHeight;
                    lbMessage.TopIndex = Math.Max(lbMessage.Items.Count - visibleItems + 1, 0);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Recieve Data Failed：" + ex.Message);
                return;
            }

        }
        /*
         * METHOD NAME: btnSendMessage_Click
         * RETURN VALUE: void
         * PARAMETERS: object sender, EventArgs e
         * DESCRIPTION: send message button event
         */
        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbSendMessage.Text))
                {
                    return;
                }
                ClientObject.SendData(tbName.Text + " say: " + tbSendMessage.Text);//send message
                tbSendMessage.Clear();//clean data in textbox
            }
            catch (Exception ex)
            {
                MessageBox.Show("Send Data Failed:" + ex.Message);
                return;
            }
        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e) {
            ClientObject.Disconnect();
        }
    }
}
