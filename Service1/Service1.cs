using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using SupportLibrary;
using System.Configuration;

namespace Service1
{
    public partial class Service1 : ServiceBase
    {
        private Timer timer1 = null;
        private string _fileName = "";
        EventLog eventLog1;
        private int eventId = 1;

        public Service1()
        {
            InitializeComponent();
            _fileName = AppDomain.CurrentDomain.BaseDirectory + "\\LogFile_Service1.txt";

            //set service can pause and resume
            this.CanPauseAndContinue = true;
            try
            {
                //eventLog1 = new EventLog(logName, ".", eventSourceName);
                eventLog1 = new System.Diagnostics.EventLog();
                //must set AutoLog to false in order to use a custom log.
                this.AutoLog = false;

                var appSettings = ConfigurationManager.AppSettings;
                if (appSettings == null)
                {
                    SupportLibrary.UtilityHelpers.WriteLog(_fileName, "appSettings == null");
                }

                //default name
                string eventSourceName = "MySource";
                string logName = "MyNewLog";
                //get config from file
                string value = "";
                value = appSettings["EventSourceName"];
                if (value.Length != 0)
                    eventSourceName = value;
                value = appSettings["EventLogName"];
                if (value.Length != 0)
                    logName = value;

                //bool isDeleteEventFirst = false;
                //value = appSettings["EventRecreate"];
                //if (Convert.ToInt32(value) == 1)
                //{
                //    isDeleteEventFirst = true;
                //}

                //clean up
                //if (isDeleteEventFirst)
                //{
                //    if (System.Diagnostics.EventLog.SourceExists(eventSourceName))
                //    {
                //        System.Diagnostics.EventLog.DeleteEventSource(eventSourceName);
                //        System.Diagnostics.EventLog.Delete(logName);
                //    }
                //}

                //create if not exist
                //if (!System.Diagnostics.EventLog.SourceExists(eventSourceName))
                //{
                //    System.Diagnostics.EventLog.CreateEventSource(
                //        eventSourceName, logName);
                //}


                eventLog1.Source = eventSourceName;
                eventLog1.Log = logName;

                SupportLibrary.UtilityHelpers.WriteLog(_fileName, "initialed EventLog");
            }
            catch (Exception e)
            {
                SupportLibrary.UtilityHelpers.WriteLog(_fileName, e.ToString());
            }

        }

        protected override void OnStart(string[] args)
        {
            timer1 = new Timer();
            this.timer1.Interval = 3000;//3sec
            this.timer1.Elapsed += new System.Timers.ElapsedEventHandler(this.timer1_Tick);
            this.timer1.Enabled = true;

            if (Environment.UserInteractive)
            {
                Console.WriteLine("Service running in console mode...");
                SupportLibrary.UtilityHelpers.WriteLog(_fileName, "Service_1 running in console mode...");
            }
            else
            {
                SupportLibrary.UtilityHelpers.WriteLog(_fileName, "Service_1 running");
            }
            // write an entry to the log
            var appSettings = ConfigurationManager.AppSettings;
            eventLog1.Log = appSettings["EventLogName"];
            eventLog1.WriteEntry("In OnStart.");
        }

        protected override void OnStop()
        {
            

            if (Environment.UserInteractive)
            {
                Console.WriteLine("Service Stopped in console mode...");
                SupportLibrary.UtilityHelpers.WriteLog(_fileName, "Service_1 Stopped in console mode...");
            }
            else
            {
                SupportLibrary.UtilityHelpers.WriteLog(_fileName, "Service_1 Stopped");
            }
            // write an entry to the log
            eventLog1.WriteEntry("In OnStop.");
        }

        protected override void OnContinue()
        {
            //continue the work
            //enable the timer
            this.timer1.Enabled = true;
            eventLog1.WriteEntry("In OnContinue.");
        }

        protected override void OnPause()
        {
            //pause works
            //stop the timer
            this.timer1.Enabled = false;
            eventLog1.WriteEntry("OnPause.");
        }  

        private void timer1_Tick(object sender, ElapsedEventArgs e)
        {
            SupportLibrary.UtilityHelpers.WriteLog(_fileName, "timer1_Tick");

            // TODO: Insert monitoring activities here.
            eventLog1.WriteEntry("Monitoring the System", EventLogEntryType.Information, eventId++);
        }

        public void TestStartupAndStop(string[] args)
        {
            this.OnStart(args);
            Console.WriteLine("Press any key to stop program");
            Console.ReadLine();
            this.OnStop();
        }  
    }
}
