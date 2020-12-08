using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Security;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace InformationInTransit.AirDrop.Calculator
{
    [ServiceContract(Namespace = "http://InformationInTransit.AirDrop.Calculator")]
    public interface ICalculator
    {
        // Step7: Create the method declaration for the contract.
        [OperationContract]
        double Add(double n1, double n2);
        [OperationContract]
        double Subtract(double n1, double n2);
        [OperationContract]
        double Multiply(double n1, double n2);
        [OperationContract]
        [FaultContractAttribute(
            typeof(MathFault),
            Action = "http://www.contoso.com/GreetingFault",
            ProtectionLevel = ProtectionLevel.EncryptAndSign
        )]
        double Divide(double n1, double n2);
    }

    [DataContractAttribute]
    public partial class MathFault
    {
        public MathFault(string message)
        {
            this.Message = message;
        }

        [DataMemberAttribute]
        public string Message
        {
            get;
            set;
        }
    }

    // Step 1: Create service class that implements the service contract.
    public partial class CalculatorService : ICalculator
    {
        // Step 2: Implement functionality for the service operations.
        public double Add(double n1, double n2)
        {
            double result = n1 + n2;
            Console.WriteLine("Received Add({0},{1})", n1, n2);
            // Code added to write output to the console window.
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Subtract(double n1, double n2)
        {
            double result = n1 - n2;
            Console.WriteLine("Received Subtract({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Multiply(double n1, double n2)
        {
            double result = n1 * n2;
            Console.WriteLine("Received Multiply({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }

        public double Divide(double n1, double n2)
        {
            if (n2 == 0)
            {
                throw new FaultException<MathFault>
                (
                    new MathFault
                    (
                        String.Format
                        (
                            "A Math error occurred. You said: {0}/{1}",
                            n1,
                            n2
                        )
                    )
                );

                throw new Exception("Division by zero!");
            }
            double result = n1 / n2;
            Console.WriteLine("Received Divide({0},{1})", n1, n2);
            Console.WriteLine("Return: {0}", result);
            return result;
        }
    }

    public partial class CalculatorServer
    {
        public static void Main(string[] args)
        {
            // Step 1 of the address configuration procedure: Create a URI to serve as the base address.
            Uri baseAddress = new Uri("http://localhost:8000/InformationInTransit.AirDrop.Calculator");

            // Step 2 of the hosting procedure: Create ServiceHost
            ServiceHost selfHost = new ServiceHost(typeof(CalculatorService), baseAddress);

            try
            {
                // Step 3 of the hosting procedure: Add a service endpoint.
                selfHost.AddServiceEndpoint(
                    typeof(ICalculator),
                    new WSHttpBinding(),
                    "CalculatorService");

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
