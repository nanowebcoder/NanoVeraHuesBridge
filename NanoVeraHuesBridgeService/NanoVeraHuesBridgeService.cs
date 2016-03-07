using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace NanoVeraHuesBridgeService
{

    
        
    public partial class NanoVeraHuesBridgeService : ServiceBase
    {

        private VeraHuesBridge.SSDPService svcSSDP;
        private VeraHuesBridge.WebServer ws;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public NanoVeraHuesBridgeService()
        {
            InitializeComponent();

            //ensures the executable directory is the base dir and not c:\windows\system32
            //otherwise nLog requires a fullpath for filenames
            System.IO.Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory); 
        }

        protected override void OnStart(string[] args)
        {
           

            logger.Info("OnStart: starting svcSSDP");
            logger.Info("OnStart: Configuration: MulticastIP [{0}] MulticastPort[{1}] LocalIP [{2}] LocalPort [{3}] UniqueID [{4}] DefaultIntensity [{5}] RespondToSSDP [{6}] BaseDir [{7}] ",
                                                                Properties.Settings.Default.MulticastIP,
                                                                 Properties.Settings.Default.MulticastPort,
                                                                 Properties.Settings.Default.LocalIP,
                                                                 Properties.Settings.Default.LocalPort,
                                                                 Properties.Settings.Default.UniqueID,
                                                                 Properties.Settings.Default.DefaultIntensity,
                                                                 Properties.Settings.Default.RespondToSSDP,
                                                                 AppDomain.CurrentDomain.BaseDirectory
                                                                );

            if (Properties.Settings.Default.RespondToSSDP)
            {
                logger.Info("OnStart: SSDP configured to respond to request.   Starting SSDP service...");
                svcSSDP = new VeraHuesBridge.SSDPService(Properties.Settings.Default.MulticastIP,
                                                                     Properties.Settings.Default.MulticastPort,
                                                                     Properties.Settings.Default.LocalIP,
                                                                     Properties.Settings.Default.LocalPort,
                                                                     Properties.Settings.Default.UniqueID);  //init on localIP

                svcSSDP.Start();
                logger.Info("OnStart: SSDP started.");
            }

            logger.Info("OnStart: Webserver starting...");
            string deviceConfigFile = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DeviceConfig.txt");
            ws = new VeraHuesBridge.WebServer(Properties.Settings.Default.LocalIP,
                                             Properties.Settings.Default.LocalPort,
                                            Properties.Settings.Default.UniqueID,
                                            Properties.Settings.Default.DefaultIntensity,
                                            deviceConfigFile);
            ws.Start();
            logger.Info("OnStart: WS started. System is up.");

        }

        protected override void OnStop()
        {
            logger.Info("OnStop: Service is shutting down...");
            svcSSDP.Stop();
            logger.Info("OnStop: SSDP listener is down.");
            ws.Stop();
            logger.Info("OnStop: Webserver is down.");
            logger.Info("OnStop: Service is down.");
        }
    }
}
