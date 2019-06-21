using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Service1
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();

            var appSettings = System.Configuration.ConfigurationManager.AppSettings;

            string eventSourceName = appSettings["EventSourceName"];
            string logName = appSettings["EventLogName"];

            EventLogInstaller EventLogInstall = null;
            foreach (Installer I in this.serviceInstaller1.Installers)
            {
                EventLogInstall = I as EventLogInstaller;

                if (EventLogInstall != null)
                {
                    EventLogInstall.Log = logName;
                    EventLogInstall.Source = eventSourceName;
                    //EventLogInstall.UninstallAction = UninstallAction.NoAction;
                    EventLogInstall.UninstallAction = UninstallAction.Remove;
                    break;
                }
            } 
        }
    }
}
