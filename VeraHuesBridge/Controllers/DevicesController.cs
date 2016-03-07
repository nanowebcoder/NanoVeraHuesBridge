using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;
using NLog;
using System.Web.Http.Cors;

namespace VeraHuesBridge
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DevicesController: ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        //GET /api/devices/{idString}
        public HttpResponseMessage Get(string id)
        {
            logger.Info("DeviceController Get called. (/api/devices/{idString}) id {0}]...", id);
            if (String.IsNullOrEmpty(id))
            {
                logger.Warn("DeviceController Get called but Id was not supplied.");
                return new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    ReasonPhrase = "Did not specify a device id."
                };
            }

            Device device = Globals.DeviceList.FindById(id);
            if (device == null)
            {
                logger.Warn("DeviceController Get called but Id did not match existing device.");
                return new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    ReasonPhrase = "Could locate a device with that id." 
                };
            }
            else
            {
                logger.Info("DeviceController Get returned device with name [{0}] for id[{1}].", device.name, device.id);
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, device);
            }

        }

        //GET /api/devices
        public HttpResponseMessage Get()
        {
            logger.Info("DeviceController called (//GET /api/devices)");
            //return new HttpResponseMessage()
            //{
            //    Content = new StringContent(Globals.DeviceList.ToString(), Encoding.UTF8, "application/json")
            //};
            DeviceContainer container = new DeviceContainer(Globals.DeviceList.List());
            List<DeviceContainer> listContainer = new List<DeviceContainer>();
            listContainer.Add(container);
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, listContainer);
            //return Globals.DeviceList;
            
        }

        // POST api/devices
        public HttpResponseMessage Post([FromBody]Device newDevice)
        {
            // expecting to see something like (although may come without an id):
            // {"id":"26a09317-0605-4ef5-b749-b53f78fde428","name":"Test","deviceType":"switch","offUrl":"http://www.google.com","onUrl":"http://www.yahoo.com","httpVerb":null,"contentType":null,"contentBody":null}
            logger.Info("DeviceController POST called (//POST /api/devices)...");
            if (newDevice==null)
            {
                logger.Warn("DeviceController POST: ContentBody did not contain a Device.");
                return new HttpResponseMessage()
                {
                     StatusCode= System.Net.HttpStatusCode.BadRequest,
                     ReasonPhrase="ContentBody did not contain a Device"
                    
                };
            }
                
            //throw an error if they are posting the same device 
            Device device=null;
            if (!String.IsNullOrEmpty(newDevice.id)) device =Globals.DeviceList.FindById(newDevice.id);

            if (device!=null || Globals.DeviceList.Contains(newDevice))
            {
                logger.Warn("DeviceController POST: Device already exists.  Use PUT to update.");
                return new HttpResponseMessage()
                {
                     StatusCode= System.Net.HttpStatusCode.BadRequest,
                     ReasonPhrase="Device already exists.  Use PUT to update."
                };
            }


            Globals.DeviceList.Add(newDevice);
            logger.Info("Device created.");
            return new HttpResponseMessage()
            {
                StatusCode = System.Net.HttpStatusCode.OK
            };

            
        }

        // PUT api/devices
        public HttpResponseMessage Put([FromBody]Device updatedDevice)
        {
            // expecting to see something like (although may come without an id):
            // {"id":"26a09317-0605-4ef5-b749-b53f78fde428","name":"Test","deviceType":"switch","offUrl":"http://www.google.com","onUrl":"http://www.yahoo.com","httpVerb":null,"contentType":null,"contentBody":null}
            logger.Info("DeviceController PUT called (//PUT /api/devices)...");
            if (updatedDevice == null)
            {
                logger.Warn("DeviceController PUT: ContentBody did not contain a Device.");
                return new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    ReasonPhrase = "ContentBody did not contain a Device"

                };
            }



            if (Globals.DeviceList.Update(updatedDevice))
            {
                logger.Info("Device updated.");
                return new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            else
            {
                logger.Warn("DeviceController PUT: Failed to update device.  Unable to locate device by id.");
                return new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    ReasonPhrase = "Failed to update device.  Unable to locate device by id."

                };
            }
            


        }

        // DELETE api/devices/{idstring}
        public HttpResponseMessage Delete(string id)
        {
            logger.Info("DeviceController DELETE called (//PUT /api/devices) with id [{0}]...", id);
            if (String.IsNullOrEmpty(id))
            {
                logger.Warn("DeviceController DELETE: Did not specify a device id.");
                return new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    ReasonPhrase = "Did not specify a device id."

                };
            }

        

            if (Globals.DeviceList.RemoveById(id))
            {
                logger.Info("Device deleted.");
                return new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.OK
                };
            }
            else
            {
                logger.Warn("DeviceController DELETE: Failed to delete device.  Unable to locate device by id.");
                return new HttpResponseMessage()
                {
                    StatusCode = System.Net.HttpStatusCode.NotFound,
                    ReasonPhrase = "Failed to delete device.  Unable to locate device by id."

                };
            }



        }

    }
}
