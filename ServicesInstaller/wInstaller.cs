using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServicesInstaller
{
    public partial class wInstaller : Form
    {
        // This delegate enables asynchronous calls for setting
        // the text property on a TextBox control.
        delegate void SetTextCallback(string text);
        delegate void UpdateUIValueCallback();

        private List<string> _serviceExecutionNameList;
        private string _selectServiceExecutionName;
        private ServiceInfo _serviceInfo;
        private bool isInstallWorkerRunning;

        public wInstaller()
        {
            InitializeComponent();
            _selectServiceExecutionName = "";
            _serviceInfo = null;
            isInstallWorkerRunning = false;
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
            if (isInstallWorkerRunning)
            {
                MessageBox.Show("Process is running.");
                return;
            }
            isInstallWorkerRunning = true;

            txtProcessOutput.Text = "";
            btnServiceInstall.Enabled = false;
            btnServiceUninstall.Enabled = false;
            btnStartService.Enabled = false;
            btnStopService.Enabled = false;


            string installPath = _serviceInfo.ServicePath;
            ServiceInstallWorker serviceInstallWorker = new ServiceInstallWorker();
            serviceInstallWorker.StandardOutputCallback += new ServiceInstallWorker.StandardOutputDelegate(this.UpdateProcessOutput);
            serviceInstallWorker.ThreadFinishRunningEvent += new ServiceInstallWorker.ThreadFinishRunningDelegate(this.InstallThreadFinished);
            serviceInstallWorker.RunInstall(installPath);
        }

        private void btnServiceUninstall_Click(object sender, EventArgs e)
        {
            if (_serviceInfo == null) { return; }
            if (_serviceInfo.IsInstalled == false) { return; }
            if (isInstallWorkerRunning)
            {
                MessageBox.Show("Process is running.");
                return;
            }
            isInstallWorkerRunning = true;

            txtProcessOutput.Text = "";
            btnServiceInstall.Enabled = false;
            btnServiceUninstall.Enabled = false; 
            btnStartService.Enabled = false;
            btnStopService.Enabled = false;


            string installedPath = _serviceInfo.ServiceInstalledPath;
            ServiceInstallWorker serviceInstallWorker = new ServiceInstallWorker();
            serviceInstallWorker.StandardOutputCallback += new ServiceInstallWorker.StandardOutputDelegate(this.UpdateProcessOutput);
            serviceInstallWorker.ThreadFinishRunningEvent += new ServiceInstallWorker.ThreadFinishRunningDelegate(this.InstallThreadFinished);
            serviceInstallWorker.RunUninstall(installedPath);
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
            if (txtServiceVersion.InvokeRequired) 
            { //called from other thread
                UpdateUIValueCallback d = new UpdateUIValueCallback(updateUIValue);
                this.Invoke(d);
                return;
            }

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
                btnServiceInstall.Enabled = false;
                btnServiceUninstall.Enabled = true;
                btnRestartService.Enabled = true;
                if (_serviceInfo.ServiceInstalledStatus == System.ServiceProcess.ServiceControllerStatus.Running.ToString())
                {
                    btnStartService.Enabled = false;
                    btnStopService.Enabled = true;
                }
                else if( _serviceInfo.ServiceInstalledStatus == System.ServiceProcess.ServiceControllerStatus.Stopped.ToString() )
                {
                    btnStartService.Enabled = true;
                    btnStopService.Enabled = false;
                }
            }
            else
            {
                this.txtServiceInstalled.Text = "False";
                this.txtServiceStatus.Text = "";
                this.txtServiceInstalledVersion.Text = "";
                this.txtServiceInstalledPath.Text = "";
                btnServiceInstall.Enabled = true;
                btnServiceUninstall.Enabled = false;
                btnStartService.Enabled = false;
                btnStopService.Enabled = false;
                btnRestartService.Enabled = false;
            }
        }

        private void UpdateProcessOutput(string pOutput)
        {
            pOutput += "\n";

            //create a thread to update ui
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.txtProcessOutput.InvokeRequired)
            {//call from other thread
                SetTextCallback d = new SetTextCallback(UpdateProcessOutput);
                this.Invoke(d, new object[] { pOutput });
            }
            else
            {//call from created thread
                this.txtProcessOutput.AppendText(pOutput);
            }
        }

        private void InstallThreadFinished()
        {
            isInstallWorkerRunning = false;
            updateUIValue();

            if (_serviceInfo != null && _serviceInfo.ServiceInstalledStatus.Length != 0 && _serviceInfo.ServiceInstalledStatus == System.ServiceProcess.ServiceControllerStatus.Stopped.ToString())
            {
                string message = string.Format("Do you want to start service now? Service Name: {0}", _serviceInfo.ServiceName);
                DialogResult dialogResult = MessageBox.Show(message, "Confirm to start service.", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    btnStartService_Click(null, null);
                }
                else if (dialogResult == DialogResult.No)
                {
                   
                }
            }
            MessageBox.Show("Done.");
        }

        private void btnStartService_Click(object sender, EventArgs e)
        {
            if (_serviceInfo == null) { return; }
            if (isInstallWorkerRunning)
            {
                MessageBox.Show("Process is running.");
                return;
            }

            string serviceName = _serviceInfo.ServiceName;
            ServiceController service = new ServiceController(serviceName);
            try
            {
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running);
                updateUIValue();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnRestartService_Click(object sender, EventArgs e)
        {
            if (_serviceInfo == null) { return; }
            if (isInstallWorkerRunning)
            {
                MessageBox.Show("Process is running.");
                return;
            }

            string serviceName = _serviceInfo.ServiceName;
            ServiceController service = new ServiceController(serviceName);
            try
            {
                if ((_serviceInfo.ServiceInstalledStatus.Length != 0) && (_serviceInfo.ServiceInstalledStatus == System.ServiceProcess.ServiceControllerStatus.Running.ToString()))
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped);
                }

                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running);

                updateUIValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnStopService_Click(object sender, EventArgs e)
        {
            if (_serviceInfo == null) { return; }
            if (isInstallWorkerRunning)
            {
                MessageBox.Show("Process is running.");
                return;
            }

            string serviceName = _serviceInfo.ServiceName;
            ServiceController service = new ServiceController(serviceName);
            try
            {
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped);
                updateUIValue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
