using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using VeraHuesBridge;

namespace DeviceEditor
{
    public partial class frmMain : Form
    {
        //public List<VeraHuesBridge.Device> deviceList;
        public BindingList<VeraHuesBridge.Device> deviceList;

        public frmMain()
        {
            InitializeComponent();
        }

         private void BindObjects()
        {
            devicesBindingSource.DataSource = this.deviceList;

            gridDevices.AutoGenerateColumns = true;

            txtDeviceName.DataBindings.Clear();
            txtDeviceId.DataBindings.Clear();
            txtOffUrl.DataBindings.Clear();
            txtOnUrl.DataBindings.Clear();

            txtDeviceType.DataBindings.Clear();
            txtContentType.DataBindings.Clear();
            txtHttpVerb.DataBindings.Clear();
            txtContentBody.DataBindings.Clear();

            txtDeviceName.DataBindings.Add(new Binding("Text", devicesBindingSource, "name"));
            txtDeviceId.DataBindings.Add(new Binding("Text", devicesBindingSource, "id"));
            txtOffUrl.DataBindings.Add(new Binding("Text", devicesBindingSource, "offUrl"));
            txtOnUrl.DataBindings.Add(new Binding("Text", devicesBindingSource, "onUrl"));

            txtDeviceType.DataBindings.Add(new Binding("Text", devicesBindingSource, "deviceType"));
            txtContentType.DataBindings.Add(new Binding("Text", devicesBindingSource, "contentType"));
            txtHttpVerb.DataBindings.Add(new Binding("Text", devicesBindingSource, "httpVerb"));
            txtContentBody.DataBindings.Add(new Binding("Text", devicesBindingSource, "contentBody")); 
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.devicesBindingSource.AddingNew +=new AddingNewEventHandler(devicesBindingSource_AddingNew);
            this.devicesBindingSource.CurrentChanged += new System.EventHandler(this.devicesBindingSource_CurrentChanged);

        }

        private void btnLoadDevices_Click(object sender, EventArgs e)
        {
            LoadData();   
        }

        private void LoadData()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(txtApiURL.Text);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // New code:
                    HttpResponseMessage response = client.GetAsync(txtApiURL.Text).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        string responseString = response.Content.ReadAsStringAsync().Result;

                        List<VeraHuesBridge.DeviceContainer> list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<VeraHuesBridge.DeviceContainer>>(responseString);
                        this.deviceList = new BindingList<VeraHuesBridge.Device>(list[0].content);

                        BindObjects();



                    }
                }
            }
            catch (Exception ex)
            {
            }
        }


        public void devicesBindingSource_AddingNew(object sender,AddingNewEventArgs e)
        {
            //VeraHuesBridge.Device device = (VeraHuesBridge.Device) e.NewObject;
            //System.Diagnostics.Debug.WriteLine(device.name);
            
        }

        private void devicesBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            //VeraHuesBridge.Device device = (VeraHuesBridge.Device) devicesBindingSource.Current;
            //System.Diagnostics.Debug.WriteLine(device.name);
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Device d = (Device) devicesBindingSource.Current;
            if (d == null ||  
                String.IsNullOrEmpty(d.name) || 
                String.IsNullOrEmpty(d.offUrl) || 
                String.IsNullOrEmpty(d.onUrl) 
                
                )
            {
                MessageBox.Show("You must fill out at a minimum the Name, onUrl and offUrl.");
                return;
            }
            //wipe out the id
            d.id = null;

            HttpResponseMessage response = PerformWebFunction(txtApiURL.Text, d, HttpMethod.Post);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Successfully Added Record!");
                LoadData();
            }
            else
            {
                MessageBox.Show(string.Format("Failed to save record. StatusCode [{0}] ReasonPhrase [{1}]", response.StatusCode, response.ReasonPhrase));
            }
            
            
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Device device = (Device) devicesBindingSource.Current;
            if (device == null ||  
                String.IsNullOrEmpty(device.name) || 
                String.IsNullOrEmpty(device.offUrl) || 
                String.IsNullOrEmpty(device.onUrl) 
                )
            {
                MessageBox.Show("You must fill out at a minimum the Name, onUrl and offUrl.");
                return;
            }

            string url=txtApiURL.Text + "/" + device.id;
            HttpResponseMessage response = PerformWebFunction(url, device, HttpMethod.Put);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Successfully Updated Record!");
                LoadData();
            }
            else
            {
                MessageBox.Show(string.Format("Failed to update record. StatusCode [{0}] ReasonPhrase [{1}]", response.StatusCode, response.ReasonPhrase));
            }

          
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {            
            Device device = (Device) devicesBindingSource.Current;
            if (device == null ||  
                String.IsNullOrEmpty(device.id) 
                )
            {
                MessageBox.Show("You must select a device.");
                return;
            }

            string url=txtApiURL.Text + "/" + device.id;
            HttpResponseMessage response = PerformWebFunction(url, device, HttpMethod.Delete);
            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Successfully Deleted Record!");
                LoadData();
            }
            else
            {
                MessageBox.Show(string.Format("Failed to delete record. StatusCode [{0}] ReasonPhrase [{1}]", response.StatusCode, response.ReasonPhrase));
            }
        
        }


        private HttpResponseMessage PerformWebFunction(string url, Device device, HttpMethod method)
        {


            HttpResponseMessage response = null;

            using (HttpClient client = new HttpClient())
            {
                string deviceData = Newtonsoft.Json.JsonConvert.SerializeObject(device);
                HttpContent content = new StringContent(deviceData, Encoding.UTF8, "application/json");
                if (method==HttpMethod.Post)
                {
                    response=client.PostAsync(url, content).Result;
                } 
                if (method==HttpMethod.Put)
                {
                    response=client.PutAsync(url, content).Result;
                } 
                if (method==HttpMethod.Delete)
                {
                    response=client.DeleteAsync(url).Result;
                } 
                if (response==null)
                        throw new ApplicationException("Unsupported HTTP method.");
                }
                
               return response;
            }



    }
}
