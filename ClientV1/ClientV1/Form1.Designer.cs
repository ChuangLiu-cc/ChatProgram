namespace ClientV1
{
    partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMsg = new System.Windows.Forms.Label();
            this.lbMessage = new System.Windows.Forms.ListBox();
            this.tbSendMessage = new System.Windows.Forms.TextBox();
            this.lblSendMessage = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbIPAddress = new System.Windows.Forms.TextBox();
            this.lblServerIP = new System.Windows.Forms.Label();
            this.lblServerPort = new System.Windows.Forms.Label();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(13, 13);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(47, 12);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "Message";
            // 
            // lbMessage
            // 
            this.lbMessage.FormattingEnabled = true;
            this.lbMessage.ItemHeight = 12;
            this.lbMessage.Location = new System.Drawing.Point(15, 29);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(360, 316);
            this.lbMessage.TabIndex = 1;
            // 
            // tbSendMessage
            // 
            this.tbSendMessage.Location = new System.Drawing.Point(15, 409);
            this.tbSendMessage.Name = "tbSendMessage";
            this.tbSendMessage.Size = new System.Drawing.Size(360, 21);
            this.tbSendMessage.TabIndex = 2;
            // 
            // lblSendMessage
            // 
            this.lblSendMessage.AutoSize = true;
            this.lblSendMessage.Location = new System.Drawing.Point(15, 391);
            this.lblSendMessage.Name = "lblSendMessage";
            this.lblSendMessage.Size = new System.Drawing.Size(83, 12);
            this.lblSendMessage.TabIndex = 3;
            this.lblSendMessage.Text = "Enter Message";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(404, 29);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 12);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name: ";
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Location = new System.Drawing.Point(357, 29);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(17, 316);
            this.vScrollBar1.TabIndex = 5;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(406, 56);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(149, 21);
            this.tbName.TabIndex = 6;
            // 
            // tbIPAddress
            // 
            this.tbIPAddress.Location = new System.Drawing.Point(406, 148);
            this.tbIPAddress.Name = "tbIPAddress";
            this.tbIPAddress.Size = new System.Drawing.Size(149, 21);
            this.tbIPAddress.TabIndex = 7;
            // 
            // lblServerIP
            // 
            this.lblServerIP.AutoSize = true;
            this.lblServerIP.Location = new System.Drawing.Point(406, 111);
            this.lblServerIP.Name = "lblServerIP";
            this.lblServerIP.Size = new System.Drawing.Size(59, 12);
            this.lblServerIP.TabIndex = 8;
            this.lblServerIP.Text = "Server IP";
            // 
            // lblServerPort
            // 
            this.lblServerPort.AutoSize = true;
            this.lblServerPort.Location = new System.Drawing.Point(408, 203);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(71, 12);
            this.lblServerPort.TabIndex = 9;
            this.lblServerPort.Text = "Server Port";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(408, 238);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(147, 21);
            this.tbPort.TabIndex = 10;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(410, 322);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(145, 23);
            this.btnConnect.TabIndex = 11;
            this.btnConnect.Text = "Connect Server";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(410, 407);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(145, 23);
            this.btnSendMessage.TabIndex = 12;
            this.btnSendMessage.Text = "Send Message";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(567, 442);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.lblServerPort);
            this.Controls.Add(this.lblServerIP);
            this.Controls.Add(this.tbIPAddress);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblSendMessage);
            this.Controls.Add(this.tbSendMessage);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.lblMsg);
            this.Name = "ClientForm";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.ListBox lbMessage;
        private System.Windows.Forms.TextBox tbSendMessage;
        private System.Windows.Forms.Label lblSendMessage;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbIPAddress;
        private System.Windows.Forms.Label lblServerIP;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSendMessage;
    }
}

