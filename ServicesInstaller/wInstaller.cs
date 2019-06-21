using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServicesInstaller
{
    public partial class wInstaller : Form
    {
        private List<string> _serviceNameList;
        private string _selectServiceName;

        public wInstaller()
        {
            InitializeComponent();
            _selectServiceName = "";

        }

        private void cbServiceName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnServiceInstall_Click(object sender, EventArgs e)
        {

        }

        private void btnServiceUninstall_Click(object sender, EventArgs e)
        {

        }

        private void wInstaller_Shown(object sender, EventArgs e)
        {
            this.CenterToScreen();

            string version = System.Windows.Forms.Application.ProductVersion;
            this.lblInstallerVersion.Text = String.Format("Version:{0}", version);

            _serviceNameList = getServiceFileNames();

            cbServiceName.Items.Clear();
            foreach (string serviceName in _serviceNameList)
            {
                cbServiceName.Items.Add(serviceName);
            }
            //select first one
            if (cbServiceName.Items.Count > 0)
            {
                cbServiceName.SelectedIndex = 0;
                _selectServiceName = cbServiceName.Items[0].ToString();
            }

            updateUIValue();
        }

        private List<string> getServiceFileNames()
        {
            List<string> serviceNames = new List<string>();
            string folderPath = Environment.CurrentDirectory;
            foreach (string f in Directory.GetFiles(folderPath))
            {
                string fileName = Path.GetFileNameWithoutExtension(f);
                string fileExtension = Path.GetExtension(f);

                if (fileExtension.CompareTo(".exe") != 0) { continue; }
                else{
                    string tempExtension = Path.GetExtension(fileName);
                    if (tempExtension.Length != 0) { continue; }

                    if (fileName.CompareTo("ServicesInstaller") == 0) { continue; }

                    serviceNames.Add(fileName);
                }
            }
            return serviceNames;
        }

        private void updateUIValue()
        {


        }
    }
}
