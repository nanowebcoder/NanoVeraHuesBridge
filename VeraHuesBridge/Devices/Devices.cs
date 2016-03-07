using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using NLog;

namespace VeraHuesBridge
{
    
    public class Devices
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        private List<Device> _devices;
        private string loadedFromFileName;
        public Devices()
        {
            //null constructor
            logger.Info("New Devices created.");
            _devices = new List<Device>();
        }

        public Devices(string fileName)
        {
            logger.Info("Created Devices from file [{0}]...", fileName);
            //null constructor
            _devices = new List<Device>();

            if (!Load(fileName))
            {

                string message = string.Format("Failed to load devices from file [{0}].", fileName);
                logger.Warn(message);
                throw new ApplicationException(message);
            };
            logger.Info("Created [{0}] Device(s) from file [{1}].", _devices.Count.ToString(), fileName);

        }

        public Device FindById(string id)
        {
            logger.Info("Finding device with id [{0}]...", id);
            Device d = _devices.Find(x => x.id == id);
            if (d==null)
            {
                logger.Info("Could not find device with id [{0}].", id);
            }
            else
            {
                logger.Info("Found device named [{0}] with id [{1}].", d.name, d.id);
            }

            return d;
        }

        public bool RemoveById(string id)
        {
            logger.Info("Removing (by id) device with id [{0}]...", id);
            Device d = _devices.Find(x => x.id == id);
            if (d == null)
            {
                logger.Info("Could not remove (by id) Device with id [{0}]. Device not found.", id);
                return false;
            }

            _devices.Remove(d);
            Save();
            logger.Info("Removed (by id) device with id [{0}].", id);
            return true;
        }

        public bool Update(Device device)
        {
            logger.Info("Updating device with id [{0}]...", device.id);
            Device d = FindById(device.id);
            if (d == null)
            {
                logger.Info("Could not update Device with id []. Device not found.", device.id);
                return false;
            }
            d.name = device.name;
            d.offUrl = device.offUrl;
            d.onUrl = device.onUrl;
            d.httpVerb = device.httpVerb;
            d.deviceType = device.deviceType;
            d.contentBody = d.contentBody;
            d.contentType = d.contentType;

            Save();
            logger.Info("Updated device with id [{0}].", device.id);
            return true;


        }
        public void Add(Device device)
        {
            logger.Info("Adding new device with id [{0}]...", device.id);
            _devices.Add(device);
             Save();
             logger.Info("Added new device with id [{0}].", device.id);
        }

        public void Remove(Device device)
        {
            logger.Info("Removing device with id [{0}]...", device.id);
            _devices.Remove(device);
            Save();
            logger.Info("Removed device with id [{0}].", device.id);
        }

        public List<Device> List()
        {
            return _devices;
        }

        public int Count()
        {
            if (_devices == null) return 0;
            return _devices.Count;

        }
       

        public bool Load(string fileName, bool CreateIfNotExists=true)
        {
            logger.Info("Loading devices from file [{0}], creating file if it does not exists [{1}]...", fileName, CreateIfNotExists);
            _devices= new List<Device>();

            if (!System.IO.File.Exists(fileName)) //if it doesnt exist, lets create it
            {
                logger.Info("Creating file...");
                Utilities.WriteToJsonFile<List<Device>>(fileName, _devices);
            }

            loadedFromFileName=fileName;



            _devices = Utilities.ReadFromJsonFile<List<Device>>(fileName);
            logger.Info("Loaded devices from file [{0}].", fileName);
            return true;
        }

        public bool Save(string fileName=null)
        {
            logger.Info("Saving devices to file [{0}]...", fileName);
            string file;
            if (String.IsNullOrEmpty(fileName))
            {
                file = loadedFromFileName;
            }
            else
            {
                file = fileName;
            }

            if (String.IsNullOrEmpty(file))
            {
                logger.Warn("Cannot save device configuration without providing filename first.");
                throw new ApplicationException("Cannot save device configuration without providing filename first.");
            }

            Utilities.WriteToJsonFile<List<Device>>(file, _devices);
            logger.Info("Saved devices to file [{0}].", fileName);
            return true;
        }

        public bool Contains(Device device)
        {
            return _devices.Contains(device);
        }
    }
}
