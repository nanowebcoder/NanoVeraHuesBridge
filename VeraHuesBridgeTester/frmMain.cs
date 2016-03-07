using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Test
{
    public partial class frmMain : Form
    {



        public frmMain()
        {
            InitializeComponent();
        }


        
        private VeraHuesBridge.SSDPService svcSSDP= null;
        private VeraHuesBridge.WebServer ws;



        private void btnStartStop_Click(object sender, EventArgs e)
        {
                      

            if (svcSSDP != null && svcSSDP.IsRunning())
            {
                btnStartStop.Text = "Start";
                svcSSDP.Stop();
                ws.Stop();
            }
            else
            {
                btnStartStop.Text = "Stop";


                if (Properties.Settings.Default.RespondToSSDP)
                { 
                    svcSSDP = new VeraHuesBridge.SSDPService(Properties.Settings.Default.MulticastIP,
                                                            Properties.Settings.Default.MulticastPort,
                                                            Properties.Settings.Default.LocalIP, 
                                                            Properties.Settings.Default.LocalPort, 
                                                            Properties.Settings.Default.UniqueID);  //init on localIP

                    svcSSDP.Start();
                }

                string deviceConfigFile =  System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DeviceConfig.txt");
                ws = new VeraHuesBridge.WebServer(Properties.Settings.Default.LocalIP,
                                                 Properties.Settings.Default.LocalPort,
                                                Properties.Settings.Default.UniqueID,
                                                Properties.Settings.Default.DefaultIntensity,
                                                deviceConfigFile);
                ws.Start();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtMulticastIP.Text = Properties.Settings.Default.MulticastIP;
            txtMulticastPort.Text = Properties.Settings.Default.MulticastPort.ToString();
            txtLocalIP.Text = Properties.Settings.Default.LocalIP;
            txtLocalPort.Text = Properties.Settings.Default.LocalPort.ToString();
            txtUUID.Text = Properties.Settings.Default.UniqueID;

           
        }

       

        private void btnMakeUUID_Click(object sender, EventArgs e)
        {
            txtUUID.Text = VeraHuesBridge.Utilities.getRandomUUIDString();
        }

        
 




      


       
    }
}
