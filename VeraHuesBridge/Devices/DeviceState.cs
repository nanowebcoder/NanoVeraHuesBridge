using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeraHuesBridge
{
    public class DeviceState {
        public bool on {get; set;}
        public int bri { get; set; } 
        public int hue { get; set; }
        public int sat { get; set; }
        public String effect { get; set; }
        public int ct { get; set; }
        public String alert { get; set; }
        public String colormode { get; set; }
        public bool reachable { get; set; }
        public List<Double> xy { get; set; }



        public override String ToString()
        {
            return "DeviceState{" +
                    "on=" + on.ToString() +
                    ", bri=" + bri.ToString() +
                    '}';
        }
    }
}
