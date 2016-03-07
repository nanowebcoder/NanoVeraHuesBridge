using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeraHuesBridge
{
    public class DeviceContainer
    {
        public List<Device> content { get; set; }
        public List<string> facets { get; set; }
        public int totalElements { get; set; }
        public int totalPages { get; set; }
        public int size { get; set; }
        public int number { get; set; }
        public bool last { get; set; }
        public int numberOfElements { get; set; }
        public string sort { get; set; }
        public bool first { get; set; }

        public DeviceContainer()
        {
            totalPages = 1;
            last = true;
            first = true;
            number = 0;
            totalElements = 0;
            size = 0;
            numberOfElements = 0;
            facets = new List<string>();
        }

        public DeviceContainer(List<Device> devices)
        {
            content = devices;
            totalElements = devices.Count;
            size = devices.Count;
            numberOfElements = devices.Count;

            totalPages = 1;
            last = true;
            first = true;
            number = 0;
            facets = new List<string>();
        }

    }
}
