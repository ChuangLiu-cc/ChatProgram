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
            this.lblMsg.Location = new System.Drawing.Point(13, 14);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(50, 13);
            this.lblMsg.TabIndex = 0;
            this.lblMsg.Text = "Message";
            // 
            // lbMessage
            // 
            this.lbMessage.FormattingEnabled = true;
            this.lbMessage.HorizontalScrollbar = true;
            this.lbMessage.Location = new System.Drawing.Point(15, 31);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(360, 342);
            this.lbMessage.TabIndex = 1;
            // 
            // tbSendMessage
            // 
            this.tbSendMessage.Location = new System.Drawing.Point(15, 443);
            this.tbSendMessage.Name = "tbSendMessage";
            this.tbSendMessage.Size = new System.Drawing.Size(360, 20);
            this.tbSendMessage.TabIndex = 2;
            // 
            // lblSendMessage
            // 
            this.lblSendMessage.AutoSize = true;
            this.lblSendMessage.Location = new System.Drawing.Point(15, 424);
            this.lblSendMessage.Name = "lblSendMessage";
            this.lblSendMessage.Size = new System.Drawing.Size(78, 13);
            this.lblSendMessage.TabIndex = 3;
            this.lblSendMessage.Text = "Enter Message";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(404, 31);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(41, 13);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Name: ";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(406, 61);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(149, 20);
            this.tbName.TabIndex = 6;
            // 
            // tbIPAddress
            // 
            this.tbIPAddress.Location = new System.Drawing.Point(406, 160);
            this.tbIPAddress.Name = "tbIPAddress";
            this.tbIPAddress.Size = new System.Drawing.Size(149, 20);
            this.tbIPAddress.TabIndex = 7;
            // 
            // lblServerIP
            // 
            this.lblServerIP.AutoSize = true;
            this.lblServerIP.Location = new System.Drawing.Point(406, 120);
            this.lblServerIP.Name = "lblServerIP";
            this.lblServerIP.Size = new System.Drawing.Size(51, 13);
            this.lblServerIP.TabIndex = 8;
            this.lblServerIP.Text = "Server IP";
            // 
            // lblServerPort
            // 
            this.lblServerPort.AutoSize = true;
            this.lblServerPort.Location = new System.Drawing.Point(408, 220);
            this.lblServerPort.Name = "lblServerPort";
            this.lblServerPort.Size = new System.Drawing.Size(60, 13);
            this.lblServerPort.TabIndex = 9;
            this.lblServerPort.Text = "Server Port";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(408, 258);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(147, 20);
            this.tbPort.TabIndex = 10;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(410, 349);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(145, 25);
            this.btnConnect.TabIndex = 11;
            this.btnConnect.Text = "Connect Server";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Location = new System.Drawing.Point(410, 441);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(145, 25);
            this.btnSendMessage.TabIndex = 12;
            this.btnSendMessage.Text = "Send Message";
            this.btnSendMessage.UseVisualStyleBackColor = true;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(567, 479);
            this.Controls.Add(this.btnSendMessage);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.lblServerPort);
            this.Controls.Add(this.lblServerIP);
            this.Controls.Add(this.tbIPAddress);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblSendMessage);
            this.Controls.Add(this.tbSendMessage);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.lblMsg);
            this.Name = "ClientForm";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
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
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbIPAddress;
        private System.Windows.Forms.Label lblServerIP;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnSendMessage;
    }
}

