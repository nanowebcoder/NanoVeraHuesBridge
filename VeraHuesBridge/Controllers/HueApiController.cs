using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;
using NLog;
using System.Web.Http.Cors;

namespace VeraHuesBridge.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HueApiController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public HttpResponseMessage Get(string userId)
        {
            logger.Info("ApiController GET (api/userId) called with userid [{0}]", userId);
            Dictionary<string, DeviceResponse> deviceResponseList = new Dictionary<string, DeviceResponse>();

            foreach (Device device in Globals.DeviceList.List())
            {
                DeviceResponse newDR=DeviceResponse.createResponse(device.name, device.id);
                deviceResponseList.Add(device.id.ToString(), newDR);

            }

            HueApiResponse haResponse = new HueApiResponse();
            haResponse.lights = deviceResponseList;

            logger.Info("ApiController GET (api/userId) returned HueApi device with [{0}] light(s)", deviceResponseList.Count);
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, haResponse);



        }
    }
}
