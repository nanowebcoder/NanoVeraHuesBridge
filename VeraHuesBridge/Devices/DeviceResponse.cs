using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
namespace VeraHuesBridge
{
    public class DeviceResponse
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public DeviceResponse()
        {
            pointsymbol = new Dictionary<String, String>();
            pointsymbol.Add("1", "none");
            pointsymbol.Add("2", "none");
            pointsymbol.Add("3", "none");
            pointsymbol.Add("4", "none");
            pointsymbol.Add("5", "none");
            pointsymbol.Add("6", "none");
            pointsymbol.Add("7", "none");
            pointsymbol.Add("8", "none");
        }

        public DeviceState state {get;set;}
        public String type { get; set; }
        public String name { get; set; }
        public String modelid { get; set; }
        public String manufacturername { get; set; }
        public String uniqueid { get; set; }
        public String swversion { get; set; }
        public Dictionary<String, String> pointsymbol { get; set; }
        


        public static DeviceResponse createResponse(String name, String id){
            logger.Info("Creating a device response object with name[{0}], id [{1}].", name, id);

            DeviceState deviceState = new DeviceState();
            DeviceResponse response = new DeviceResponse();
            response.state=deviceState;
            deviceState.on=false;
            deviceState.reachable=true;
            deviceState.effect="none";
            deviceState.alert="none";
            deviceState.bri=254;
            deviceState.hue=15823;
            deviceState.sat=88;
            deviceState.ct=313;

            List<Double> xv = new List<Double>();
            xv.Add(0.4255);
            xv.Add(0.3998);
            deviceState.xy=xv;

            deviceState.colormode="ct";
            response.name=name;
            response.uniqueid=id;
            response.manufacturername="Philips";
            response.type="Extended color light";
            response.modelid="LCT001";
            response.swversion="65003148";

            return response;
    }
    }
}
