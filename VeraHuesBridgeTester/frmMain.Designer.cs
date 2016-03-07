namespace Test
{
    partial class frmMain
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
            this.ofdMain = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnMakeUUID = new System.Windows.Forms.Button();
            this.txtLocalPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLocalIP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUUID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMulticastPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMulticastIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdMain
            // 
            this.ofdMain.FileName = "openFileDialog1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(737, 448);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnMakeUUID);
            this.tabPage1.Controls.Add(this.txtLocalPort);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtLocalIP);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtUUID);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtMulticastPort);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtMulticastIP);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnStartStop);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(729, 422);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Configuration";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnMakeUUID
            // 
            this.btnMakeUUID.Location = new System.Drawing.Point(395, 22);
            this.btnMakeUUID.Name = "btnMakeUUID";
            this.btnMakeUUID.Size = new System.Drawing.Size(47, 21);
            this.btnMakeUUID.TabIndex = 23;
            this.btnMakeUUID.Text = "Make";
            this.btnMakeUUID.UseVisualStyleBackColor = true;
            this.btnMakeUUID.Click += new System.EventHandler(this.btnMakeUUID_Click);
            // 
            // txtLocalPort
            // 
            this.txtLocalPort.Location = new System.Drawing.Point(125, 127);
            this.txtLocalPort.Name = "txtLocalPort";
            this.txtLocalPort.ReadOnly = true;
            this.txtLocalPort.Size = new System.Drawing.Size(317, 20);
            this.txtLocalPort.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(64, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Local Port";
            // 
            // txtLocalIP
            // 
            this.txtLocalIP.Location = new System.Drawing.Point(125, 101);
            this.txtLocalIP.Name = "txtLocalIP";
            this.txtLocalIP.ReadOnly = true;
            this.txtLocalIP.Size = new System.Drawing.Size(317, 20);
            this.txtLocalIP.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Local IPAddress";
            // 
            // txtUUID
            // 
            this.txtUUID.Location = new System.Drawing.Point(125, 23);
            this.txtUUID.Name = "txtUUID";
            this.txtUUID.ReadOnly = true;
            this.txtUUID.Size = new System.Drawing.Size(264, 20);
            this.txtUUID.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "UUID";
            // 
            // txtMulticastPort
            // 
            this.txtMulticastPort.Location = new System.Drawing.Point(125, 75);
            this.txtMulticastPort.Name = "txtMulticastPort";
            this.txtMulticastPort.ReadOnly = true;
            this.txtMulticastPort.Size = new System.Drawing.Size(317, 20);
            this.txtMulticastPort.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Multicast Port";
            // 
            // txtMulticastIP
            // 
            this.txtMulticastIP.Location = new System.Drawing.Point(125, 49);
            this.txtMulticastIP.Name = "txtMulticastIP";
            this.txtMulticastIP.ReadOnly = true;
            this.txtMulticastIP.Size = new System.Drawing.Size(317, 20);
            this.txtMulticastIP.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Multicast IPAddress";
            // 
            // btnStartStop
            // 
            this.btnStartStop.Location = new System.Drawing.Point(359, 153);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(83, 27);
            this.btnStartStop.TabIndex = 12;
            this.btnStartStop.Text = "Start/Stop";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(737, 448);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmMain";
            this.Text = "Nano Vera/Hues Bridge Tester";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdMain;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnMakeUUID;
        private System.Windows.Forms.TextBox txtLocalPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLocalIP;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUUID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMulticastPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMulticastIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartStop;
    }
}

