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
    public class SampleRemoteClient
    {
        [SecurityPermission(SecurityAction.Demand)]
        public static void Main(string[] args)
        {
            // Create the channel.
            TcpChannel clientChannel = new TcpChannel();

            // Register the channel.
            ChannelServices.RegisterChannel(clientChannel, false);

            // Register as client for remote object.
            WellKnownClientTypeEntry remoteType = new WellKnownClientTypeEntry(
                System.Type.GetType("InformationInTransit.ProcessLogic.SampleRemoteClass, SampleRemoteClass"), 
                "tcp://localhost:9090/RemoteObject.rem");
            RemotingConfiguration.RegisterWellKnownClientType(remoteType);

            // Create a message sink.
            string objectUri;
            System.Runtime.Remoting.Messaging.IMessageSink messageSink =
                clientChannel.CreateMessageSink(
                    "tcp://localhost:9090/RemoteObject.rem", null,
                    out objectUri);
            Console.WriteLine("The URI of the message sink is {0}.",
                objectUri);
            if (messageSink != null)
            {
                Console.WriteLine("The type of the message sink is {0}.",
                    messageSink.GetType().ToString());
            }

            // Create an instance of the remote object.
            SampleRemoteClass service = new SampleRemoteClass();

            // Invoke a method on the remote object.
            Console.WriteLine("The client is invoking the remote object.");
            Console.WriteLine("The remote object has been called {0} times.",
                service.GetCount());
        }
    }
}
