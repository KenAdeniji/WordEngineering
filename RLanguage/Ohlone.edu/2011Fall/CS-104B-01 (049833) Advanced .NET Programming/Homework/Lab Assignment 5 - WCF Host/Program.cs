using System;
using System.ServiceModel;
using System.ServiceModel.Description;

/*
 * Service Reference: net.tcp://localhost:9000/mex
*/
namespace Lab_Assignment_5___WCF_Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(
                typeof(DateService),
                new Uri("net.tcp://localhost:9000")))
            {
                host.Description.Behaviors.Add(new ServiceMetadataBehavior());
                host.AddServiceEndpoint(
                    typeof(IMetadataExchange),
                    MetadataExchangeBindings.CreateMexTcpBinding(),
                    "mex");
                host.AddServiceEndpoint(
                    typeof(IDateService),
                    new NetTcpBinding(),
                    "net.tcp://localhost:9000/DateService");
                host.Open();
                Console.WriteLine("press enter to stop service...");
                Console.ReadLine();

                host.Close();
            }
        }
    }
}

