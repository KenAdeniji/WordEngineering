﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Security.Permissions;

namespace InformationInTransit.ProcessLogic
{
    public class SampleRemoteServer
    {
        [SecurityPermission(SecurityAction.Demand)]
        public static void Main(string[] args)
        {
            // Create the server channel.
            TcpChannel serverChannel = new TcpChannel(9090);

            // Register the server channel.
            ChannelServices.RegisterChannel(serverChannel, false);

            // Show the name of the channel.
            Console.WriteLine("The name of the channel is {0}.",
                serverChannel.ChannelName);

            // Show the priority of the channel.
            Console.WriteLine("The priority of the channel is {0}.",
                serverChannel.ChannelPriority);

            // Show the URIs associated with the channel.
            ChannelDataStore data = (ChannelDataStore)serverChannel.ChannelData;
            foreach (string uri in data.ChannelUris)
            {
                Console.WriteLine("The channel URI is {0}.", uri);
            }

            // Expose an object for remote calls.
            RemotingConfiguration.RegisterWellKnownServiceType(
                System.Type.GetType("InformationInTransit.ProcessLogic.SampleRemoteClass, SampleRemoteClass"),
                "RemoteObject.rem",
                WellKnownObjectMode.Singleton);

            // Parse the channel's URI.
            string[] urls = serverChannel.GetUrlsForUri("RemoteObject.rem");
            if (urls.Length > 0)
            {
                string objectUrl = urls[0];
                string objectUri;
                string channelUri = serverChannel.Parse(objectUrl, out objectUri);
                Console.WriteLine("The object URL is {0}.", objectUrl);
                Console.WriteLine("The object URI is {0}.", objectUri);
                Console.WriteLine("The channel URI is {0}.", channelUri);
            }

            // Wait for the user prompt.
            Console.WriteLine("Press ENTER to exit the server.");
            Console.ReadLine();
        }
    }
}
