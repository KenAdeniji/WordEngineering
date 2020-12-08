using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using System.ServiceModel.Description;
using System.Runtime.Serialization;

namespace InformationInTransit.AirDrop.Temperature
{
    [ServiceContract(Namespace = "http://InformationInTransit.AirDrop.Temperature")]
    public interface ITemperature
    {
        [OperationContract]
        double Celsuis(double fahrenheit);
        [OperationContract]
        double Fahrenheit(double celsuis);
        [OperationContractAttribute(IsOneWay = true)]
        /*
        [OperationContractAttribute(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
        */ 
        void Hello(string greeting);

        [OperationContract]
        List<TemperatureService.Metric> Range(double start, double step, double finish, TemperatureService.Scale scale);
    }

    public class TemperatureService : ITemperature
    {
        public const double CelsuisMultiplier = 5.0D / 9.0D;
        public const double FahrenheitMultiplier = 9.0D / 5.0D;

        public double Celsuis(double fahrenheit)
        {
            double celsuis = CelsuisMultiplier * (fahrenheit - 32);
            System.Console.WriteLine
            (
                "Fahrenheit: {0} | Celsuis: {1}",
                fahrenheit,
                celsuis
            );
            return celsuis;
        }

        public double Fahrenheit(double celsuis)
        {
            double fahrenheit = (FahrenheitMultiplier * celsuis) + 32;
            System.Console.WriteLine
            (
                "Celsuis: {0} | Fahrenheit: {1}",
                celsuis,
                fahrenheit
            );
            return fahrenheit;
        }

        public void Hello(string greeting)
        {
        }

        public List<Metric> Range(double start, double step, double finish, Scale scale)
        {
            List<Metric> metrics = new List<Metric>();
            double celsuis = 0;
            double fahrenheit = 0;
            for (double metric = start; metric <= finish; metric += step)
            {
                switch (scale)
                {
                    case Scale.Celsuis:
                        celsuis = metric;
                        fahrenheit = Fahrenheit(celsuis);
                        break;

                    case Scale.Fahrenheit:
                        fahrenheit = metric;
                        celsuis = Celsuis(fahrenheit);
                        break;
                }
                metrics.Add
                (
                    new Metric
                    {
                        Celsuis = celsuis,
                        Fahrenheit = fahrenheit
                    }
                );
            }
            return metrics;
        }

        [DataContract]
        public class Metric
        {
            [DataMember]
            public double Celsuis { get; set; }
            [DataMember]
            public double Fahrenheit { get; set; }
        }

        public enum Scale
        {
            Celsuis,
            Fahrenheit
        }
    }

    public class TemperatureServer
    {
        public static void Main(string[] args)
        {
            // Step 1 of the address configuration procedure: Create a URI to serve as the base address.
            Uri baseAddress = new Uri("http://localhost:8000/InformationInTransit.AirDrop.Temperature");

            // Step 2 of the hosting procedure: Create ServiceHost
            ServiceHost selfHost = new ServiceHost(typeof(TemperatureService), baseAddress);

            try
            {
                // Step 3 of the hosting procedure: Add a service endpoint.
                selfHost.AddServiceEndpoint(
                    typeof(ITemperature),
                    new WSHttpBinding(),
                    "TemperatureService");

                // Step 4 of the hosting procedure: Enable metadata exchange.
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                // Step 5 of the hosting procedure: Start (and then stop) the service.
                selfHost.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Close the ServiceHostBase to shutdown the service.
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }
        }
    }
}
