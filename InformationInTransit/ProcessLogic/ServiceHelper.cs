using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceProcess;

namespace InformationInTransit.ProcessLogic
{
    class ServiceHelper
    {
        public static void Main(string[] argv)
        {
            //WindowsServices();
            DeviceDriverServices();
        }

        public static ServiceController[] WindowsServices()
        {
            ServiceController[] serviceControllers = ServiceController.GetServices();
            foreach (ServiceController serviceController in serviceControllers)
            {
                System.Console.WriteLine
                (
                    "ServiceName: {0} | DisplayName: {1}",
                    serviceController.ServiceName,
                    serviceController.DisplayName
                );
            }
            return serviceControllers;
        }

        public static ServiceController[] DeviceDriverServices()
        {
            ServiceController[] serviceControllers = ServiceController.GetDevices();
            foreach (ServiceController serviceController in serviceControllers)
            {
                System.Console.WriteLine
                (
                    "DisplayName: {0} | Status: {1} | ServiceType: {2}",
                    serviceController.DisplayName,
                    serviceController.Status,
                    serviceController.ServiceType
                );
            }
            return serviceControllers;
        }
    }
}
