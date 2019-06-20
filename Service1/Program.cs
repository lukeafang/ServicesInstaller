using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using SupportLibrary;

namespace Service1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                if (!SupportLibrary.UtilityHelpers.IsAdministrator())
                {
                    Console.WriteLine("Error. Please run as Administrator of this process.");
                    Console.Read();
                }
                else
                {
                    if (args.Length > 0)
                    {
                        try
                        {
                            switch (args[0])
                            {
                                case "-install":
                                    System.Configuration.Install.ManagedInstallerClass.InstallHelper(new string[] { System.Reflection.Assembly.GetExecutingAssembly().Location });
                                    break;
                                case "-uninstall":
                                    System.Configuration.Install.ManagedInstallerClass.InstallHelper(new string[] { "/u", System.Reflection.Assembly.GetExecutingAssembly().Location });
                                    break;
                                default:
                                    break;
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                    }
                    else
                    {
                        Service1 service = new Service1();
                        service.TestStartupAndStop(args);
                    }
                }
            }
            else
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[] 
                { 
                    new Service1() 
                };
                ServiceBase.Run(ServicesToRun);
            }
        }

    }
}
