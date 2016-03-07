using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeraHuesBridge
{
    public class HueApiResponse
    {
            public Dictionary<string, DeviceResponse> lights {get; set;}
    }
}
