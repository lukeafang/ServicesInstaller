using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServicesInstaller
{
    class ServiceInstallWorker
    {
        public delegate void StandardOutputDelegate(string pOutput);
        public event StandardOutputDelegate StandardOutputCallback;

        public delegate void ThreadFinishRunningDelegate();
        public event ThreadFinishRunningDelegate ThreadFinishRunningEvent;

        private string workingPath;

        public bool IsThreadRunning
        {
            get { return isThreadRunning; }
        }
        private bool isThreadRunning;

        public ServiceInstallWorker()
        {
            this.workingPath = "";
            isThreadRunning = false;
        }

        public bool RunInstall(string installPath)
        {
            if (isThreadRunning) { return false; }

            StandardOutputCallback("Install Start...");

            this.workingPath = installPath;
            Thread t = new Thread(workerThread);
            t.Start("-install");
            return true;
        }

        public bool RunUninstall(string installedPath)
        {
            if (isThreadRunning) { return false; }

            StandardOutputCallback("Uninstall Start...");

            this.workingPath = installedPath;
            Thread t = new Thread(workerThread);
            t.Start("-uninstall");
            return true;
        }

        private void workerThread(object data)
        {
            isThreadRunning = true;
            string param = data.ToString();

            using (Process process = new Process())
            {
                StandardOutputCallback("===Thread Created===");

                process.StartInfo.FileName = workingPath;
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.Arguments = param;
                process.Start();

                StandardOutputCallback("Installation Starting...");

                // Synchronously read the standard output of the spawned process. 
                StreamReader reader = process.StandardOutput;
                string standard_output;
                while ((standard_output = reader.ReadLine()) != null)
                {
                    StandardOutputCallback(standard_output);
                }
                process.WaitForExit();
            }

            StandardOutputCallback("===Thread End===");
            isThreadRunning = false;
            if (ThreadFinishRunningEvent != null)
                ThreadFinishRunningEvent();
        }

    }
}
