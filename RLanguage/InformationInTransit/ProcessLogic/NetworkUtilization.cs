using System;
using System.Diagnostics;

namespace InformationInTransit.ProcessLogic
{
    /// <summary>
    /// IPConfig /All
    /// PerfMon
    /// </summary>
    public static partial class NetworkUtilization
    {
        public static void Main(string[] argv)
        {
            Console.Title = "How to Calculate Network Utilization in .NET";
            double utilization = CalculateNetworkUtilization(argv[0]);
            Console.WriteLine("Network Utilization = {0}%", utilization);
        }

        public static double CalculateNetworkUtilization(string networkCard)
        {
            const int numberOfIterations = 10;
            PerformanceCounter bandwidthCounter =
                new PerformanceCounter("Network Interface", "Current Bandwidth", networkCard);
            float bandwidth = bandwidthCounter.NextValue();

            PerformanceCounter dataSentCounter =
                new PerformanceCounter("Network Interface", "Bytes Sent/sec", networkCard);

            PerformanceCounter dataReceivedCounter =
                new PerformanceCounter("Network Interface", "Bytes Received/sec", networkCard);

            float sendSum = 0;
            float receiveSum = 0;

            for (int index = 0; index < numberOfIterations; index++)
            {
                sendSum += dataSentCounter.NextValue();
                receiveSum += dataReceivedCounter.NextValue();
            }

            float dataSent = sendSum;
            float dataReceived = receiveSum;

            double utilization = (8 * (dataSent + dataReceived)) / (bandwidth * numberOfIterations) * 100;
            return utilization;
        }
    }
}
