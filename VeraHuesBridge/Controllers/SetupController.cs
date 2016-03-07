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
    public class SetupController : ApiController
    {
        // GET api/setup
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public HttpResponseMessage Get()
        {
            logger.Info("SetupController GET called (// GET api/setup.xml)");

            string hueTemplate = "<?xml version=\"1.0\"?>\n" +
              "<root xmlns=\"urn:schemas-upnp-org:device-1-0\">\n" +
              "<specVersion>\n" +
              "<major>1</major>\n" +
              "<minor>0</minor>\n" +
              "</specVersion>\n" +
              "<URLBase>http://{0}:{1}/</URLBase>\n" + //hostname string
              "<device>\n" +
              "<deviceType>urn:schemas-upnp-org:device:Basic:1</deviceType>\n" +
              "<friendlyName>Nano VeraHue Bridge</friendlyName>\n" +
              "<manufacturer>Royal Philips Electronics</manufacturer>\n" +
              "<manufacturerURL>http://www.nanoweb.com</manufacturerURL>\n" +
              "<modelDescription>Hue to Vera Bridge for Amazon Echo</modelDescription>\n" +
              "<modelName>Philips hue bridge 2012</modelName>\n" +
              "<modelNumber>929000226503</modelNumber>\n" +
              "<modelURL>http://www.nanoweb.com/HueVeraBridge</modelURL>\n" +
              "<serialNumber>01189998819991197253</serialNumber>\n" +
              "<UDN>uuid:{2}</UDN>\n" +
              "<serviceList>\n" +
              "<service>\n" +
              "<serviceType>(null)</serviceType>\n" +
              "<serviceId>(null)</serviceId>\n" +
              "<controlURL>(null)</controlURL>\n" +
              "<eventSubURL>(null)</eventSubURL>\n" +
              "<SCPDURL>(null)</SCPDURL>\n" +
              "</service>\n" +
              "</serviceList>\n" +
              "<presentationURL>index.html</presentationURL>\n" +
              "<iconList>\n" +
              "<icon>\n" +
              "<mimetype>image/png</mimetype>\n" +
              "<height>48</height>\n" +
              "<width>48</width>\n" +
              "<depth>24</depth>\n" +
              "<url>hue_logo_0.png</url>\n" +
              "</icon>\n" +
              "<icon>\n" +
              "<mimetype>image/png</mimetype>\n" +
              "<height>120</height>\n" +
              "<width>120</width>\n" +
              "<depth>24</depth>\n" +
              "<url>hue_logo_3.png</url>\n" +
              "</icon>\n" +
              "</iconList>\n" +
              "</device>\n" +
              "</root>\n";
            

            hueTemplate = String.Format(hueTemplate, Globals.IPAddress, Globals.Port, Globals.UUID);

            logger.Info("SetupController GET returned hue template.");
            return new HttpResponseMessage()
            {
                Content = new StringContent(hueTemplate, Encoding.UTF8, "application/xml")
            };


        }
    }
}
