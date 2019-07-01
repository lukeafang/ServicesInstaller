using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServicesInstaller
{
    public partial class wInstaller : Form
    {
        private List<string> _serviceExecutionNameList;
        private string _selectServiceExecutionName;
        private ServiceInfo _serviceInfo;

        public wInstaller()
        {
            InitializeComponent();
            _selectServiceExecutionName = "";
            _serviceInfo = null;
        }

        private void cbServiceName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = cbServiceName.SelectedItem.ToString();
            if (name.CompareTo(_selectServiceExecutionName) != 0)
            {
                _selectServiceExecutionName = name;
                updateUIValue();
            }
        }

        private void btnServiceInstall_Click(object sender, EventArgs e)
        {
            if (_serviceInfo == null) { return; }

            string installPath = _serviceInfo.ServicePath;

            using (Process process = new Process())
            {
                txtProcessOutput.Text = "";
                txtProcessOutput.Text = "Starting install service...\r\n";

                process.StartInfo.FileName = installPath;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.Arguments = "-install";
                process.Start();

                // Synchronously read the standard output of the spawned process. 
                StreamReader reader = process.StandardOutput;
                string standard_output;
                string newOutput = "";
                while ((standard_output = reader.ReadLine()) != null)
                {
                    newOutput = "\r\n" + standard_output;
                    txtProcessOutput.AppendText(newOutput);
                }

                // Write the redirected output to this application's window.
                //Console.WriteLine(output);
                //txtProcessOutput.Text = output;

                process.WaitForExit();
            }

            //reload service info to check is installed or not
            updateUIValue();
        }

        private void btnServiceUninstall_Click(object sender, EventArgs e)
        {
            if (_serviceInfo == null) { return; }
            if (_serviceInfo.IsInstalled == false) { return; }

            string installedPath = _serviceInfo.ServiceInstalledPath;

            using (Process process = new Process())
            {
                txtProcessOutput.Text = "";
                txtProcessOutput.Text = "Starting uninstall service...\r\n";

                process.StartInfo.FileName = installedPath;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.Arguments = "-uninstall";
                process.Start();

                // Synchronously read the standard output of the spawned process. 
                StreamReader reader = process.StandardOutput;
                string standard_output;
                string newOutput = "";
                while ((standard_output = reader.ReadLine()) != null)
                {
                    newOutput = "\r\n" + standard_output;
                    txtProcessOutput.AppendText(newOutput);
                }

                process.WaitForExit();
            }

            //reload service info to check is installed or not
            updateUIValue();
        }

        private void wInstaller_Shown(object sender, EventArgs e)
        {
            this.CenterToScreen();

            string version = System.Windows.Forms.Application.ProductVersion;
            this.lblInstallerVersion.Text = String.Format("Version:{0}", version);

            _serviceExecutionNameList = getServiceFileNames();

            cbServiceName.Items.Clear();
            foreach (string serviceName in _serviceExecutionNameList)
            {
                cbServiceName.Items.Add(serviceName);
            }
            //select first one
            if (cbServiceName.Items.Count > 0)
            {
                cbServiceName.SelectedIndex = 0;
                _selectServiceExecutionName = cbServiceName.Items[0].ToString();
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
            //clean text
            _serviceInfo = null;
            this.txtServiceVersion.Text = "";
            this.txtServiceInstalled.Text = "";
            this.txtServiceStatus.Text = "";
            this.txtServiceInstalledVersion.Text = "";
            this.txtServiceInstalledPath.Text = "";
            if (_selectServiceExecutionName.Length == 0) { return; }
            
            _serviceInfo = new ServiceInfo();
            string configFilePath = AppDomain.CurrentDomain.BaseDirectory + _selectServiceExecutionName + ".exe.config";
            if (_serviceInfo.LoadServiceInfo(AppDomain.CurrentDomain.BaseDirectory, _selectServiceExecutionName) == false) { return; }

            this.txtServiceVersion.Text = _serviceInfo.ServiceVersion;

            if (_serviceInfo.IsInstalled == true)
            {
                this.txtServiceInstalled.Text = "True";
                this.txtServiceStatus.Text = _serviceInfo.ServiceInstalledStatus;
                this.txtServiceInstalledVersion.Text = _serviceInfo.ServiceInstalledVersion;
                this.txtServiceInstalledPath.Text = _serviceInfo.ServiceInstalledPath;
            }
            else
            {
                this.txtServiceInstalled.Text = "False";
                this.txtServiceStatus.Text = "";
                this.txtServiceInstalledVersion.Text = "";
                this.txtServiceInstalledPath.Text = "";
            }
        }
    }
}
