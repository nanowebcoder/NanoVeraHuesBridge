using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeraHuesBridge
{
    public class Device
    {

        public Device()
        {
            _id = Guid.NewGuid();
        }

        private Guid _id; 
        
        public string id
        {
            get
            {
                return _id.ToString();
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    _id = Guid.NewGuid();
                }
                else { 
                    _id = Guid.Parse(value);
                }
            }
        }
        public String name {get; set;}
        public String deviceType {get; set;}
        public String offUrl {get; set;}
        public String onUrl {get; set;}
        public String httpVerb {get; set;}
        public String contentType{get; set;}
        public String contentBody {get; set;}

    
    

    }
}
