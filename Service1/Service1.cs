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

            try
            {
                //clean up
                //if (System.Diagnostics.EventLog.SourceExists("MySource"))
                //{
                //    System.Diagnostics.EventLog.DeleteEventSource("MySource");
                //}
                //create if not exist
                if (!System.Diagnostics.EventLog.SourceExists("MySource"))
                {
                    System.Diagnostics.EventLog.CreateEventSource(
                        "MySource", "MyNewLog");
                }
                eventLog1 = new System.Diagnostics.EventLog();
                eventLog1.Source = "MySource";
                eventLog1.Log = "MyNewLog";

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
            this.timer1.Interval = 5000;//5sec
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
