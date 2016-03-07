using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeraHuesBridge
{
    public static class Globals
    {
        public static string IPAddress;
        public static int Port;
        public static string BaseAddress;
        public static string UUID;
        public static int DefaultIntensity;

        public static string DeviceConfigFile;
        public static VeraHuesBridge.Devices DeviceList;
    }
}
