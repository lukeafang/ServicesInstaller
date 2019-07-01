using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ServicesInstaller
{
    class ServiceInfo
    {
        public string ServiceName
        {
            get { return _serviceName; }
            set { _serviceName = value; }
        }
        private string _serviceName;

        public string DisplayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }
        private string _displayName;

        public string ServiceDesc
        {
            get { return _serviceDesc; }
            set { _serviceDesc = value; }
        }
        private string _serviceDesc;

        public string ServiceVersion
        {
            get { return _serviceVersion; }
            set { _serviceVersion = value; }
        }
        private string _serviceVersion;

        public string ServicePath
        {
            get { return _servicePath; }
            set { _servicePath = value; }
        }
        private string _servicePath;

        //Service registed path, if service is installed, store installed path here
        public string ServiceInstalledPath
        {
            get { return _serviceInstalledPath; }
            set { _serviceInstalledPath = value; }
        }
        private string _serviceInstalledPath;

        public string ServiceInstalledVersion
        {
            get { return _serviceInstalledVersion; }
            set { _serviceInstalledVersion = value; }
        }
        private string _serviceInstalledVersion;

        public string ServiceInstalledStatus
        {
            get { return _serviceInstalledStatus; }
            set { _serviceInstalledStatus = value; }
        }
        private string _serviceInstalledStatus;

        public bool IsInstalled
        {
            get { return _isInstalled; }
            set { _isInstalled = value; }
        }
        private bool _isInstalled;

        public string ErrorMsg
        {
            get { return _errorMsg; }
            set { _errorMsg = value; }
        }
        private string _errorMsg;

        public ServiceInfo()
        {

        }

        //load config from file and check installed or not
        public bool LoadServiceInfo(string serviceExecutionFolder, string serviceExecutionName)
        {
            string configFilePath = serviceExecutionFolder + serviceExecutionName + ".exe.config";
            _servicePath = serviceExecutionFolder + serviceExecutionName + ".exe";
            //check file exist
            if (File.Exists(configFilePath) == false) 
            {
                _errorMsg = "Config File not exist.";
                return false;
            }
            if (File.Exists(_servicePath) == false)
            {
                _errorMsg = "Execution File not exist.";
                return false;
            }

            //get version
            FileVersionInfo installFileVersionInfo = FileVersionInfo.GetVersionInfo(_servicePath);
            _serviceVersion = installFileVersionInfo.ProductVersion;

            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = configFilePath; 

            // Get the mapped configuration file
            var config = ConfigurationManager.OpenMappedExeConfiguration(
                   configFileMap, ConfigurationUserLevel.None);

            //get the relevant section from the config object
            AppSettingsSection section = (AppSettingsSection)config.GetSection("appSettings");

            //get config value
            var keyValueConfigElement = section.Settings["ServiceName"];
            _serviceName = keyValueConfigElement.Value;

            keyValueConfigElement = section.Settings["ServiceDisplayName"];
            _displayName = keyValueConfigElement.Value;

            keyValueConfigElement = section.Settings["ServiceDesc"];
            _serviceDesc = keyValueConfigElement.Value;

            //check service installed or not
            try
            {
                ServiceController Ctl = new ServiceController(_serviceName);

                //  This will throw an exception if the service is not installed ...
                ServiceControllerStatus Status = Ctl.Status;
                _serviceInstalledStatus = Status.ToString();
                _isInstalled = true;

                //find service path
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_Service");
                ManagementObjectCollection collection = searcher.Get();
                foreach (ManagementObject obj in collection)
                {    
                    string name = obj["Name"] as string;
                    string pathName = obj["PathName"] as string;
                   
                    if (name.CompareTo(_serviceName) == 0)
                    {
                        //clean path
                        pathName = pathName.Trim('"');
                        _serviceInstalledPath = pathName;

                        FileVersionInfo installedFileVersionInfo = FileVersionInfo.GetVersionInfo(_serviceInstalledPath);
                        _serviceInstalledVersion = installedFileVersionInfo.ProductVersion;
                        break;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                _serviceInstalledVersion = "";
                _serviceInstalledStatus = "";
                _serviceInstalledPath = "";
                _isInstalled = false;
            }

            return true;
        }
    }
}
