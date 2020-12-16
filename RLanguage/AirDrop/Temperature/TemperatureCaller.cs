using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using System.ServiceModel.Description;

namespace InformationInTransit.AirDrop.Temperature
{
    class TemperatureCaller
    {
        public static void Main(string[] argv)
        {
            //Step 1: Create an endpoint address and an instance of the WCF Client.
            EndpointAddress epAddress = new EndpointAddress("http://localhost:8000/ServiceModelSamples/Service/TemperatureService");
            TemperatureClient client = new TemperatureClient();

            // Step 2: Call the service operations.
            // Call the Celsuis service operation.
            double fahrenheit = 32.00D;
            double celsuis = client.Celsuis(fahrenheit);
            System.Console.WriteLine
            (
                "Fahrenheit: {0} | Celsuis: {1}",
                fahrenheit,
                celsuis
            );

            // Call the Fahrenheit service operation.
            celsuis = 100.00D;
            fahrenheit = client.Fahrenheit(celsuis);
            System.Console.WriteLine
            (
                "Celsuis: {0} | Fahrenheit: {1}",
                celsuis,
                fahrenheit
            );
            
            TemperatureServiceMetric[] range = client.Range(32, 20, 212, TemperatureServiceScale.Fahrenheit);

            foreach (TemperatureServiceMetric metric in range)
            {
                System.Console.WriteLine
                (
                    "Fahrenheit: {0} | Celsuis: {1}",
                    metric.Fahrenheit,
                    metric.Celsuis
                );
            }
                
            //Step 3: Closing the client gracefully closes the connection and cleans up resources.
            client.Close();

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}
