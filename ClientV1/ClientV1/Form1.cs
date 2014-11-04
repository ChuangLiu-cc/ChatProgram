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
        private Client ClientObj = new Client();

        public ClientForm()
        {
            InitializeComponent();
        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            btnSendMessage.Enabled = false; //can not send meassage if not connection
            this.AcceptButton = btnSendMessage;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            string nickName = tbName.Text;
            string ip = tbIPAddress.Text;
            string port = tbPort.Text;

            if (string.IsNullOrEmpty(nickName) || string.IsNullOrEmpty(ip) || string.IsNullOrEmpty(port))
            {
                MessageBox.Show("Please completely enter your name and server IP address...");
                return;
            }

            try
            {

                ClientObj.SendConnection(ip, Convert.ToInt32(port)); 

                ClientObj.receiveEvent += new Client.receiveDelegate(ClientObj_receiveEvent);

                ClientObj.Send(tbName.Text + " login succeed!");

                btnSendMessage.Enabled = true;
                btnConnect.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connecting Mistake:" + ex.Message);
                return;
            }
        }

        void ClientObj_receiveEvent(string receiveData)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    Client.receiveDelegate update = new Client.receiveDelegate(ClientObj_receiveEvent);

                    this.Invoke(update, new object[] { receiveData });//send message to thread 
                }
                else
                {
                    lbMessage.Items.Add(receiveData);//add data
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Recieve Data Failed：" + ex.Message);
                return;
            }

        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbSendMessage.Text))
                {
                    return;
                }
                ClientObj.Send(tbName.Text + " say: " + tbSendMessage.Text);//send message
                tbSendMessage.Clear();//clean data
            }
            catch (Exception ex)
            {
                MessageBox.Show("Send Data Failed:" + ex.Message);
                return;
            }
        }

        private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void ClientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            ClientObj.tcpClientObject.Close();//close connection
            this.Close();//close form
        }
    }
}
