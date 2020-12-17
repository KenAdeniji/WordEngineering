using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace InformationInTransit.ProcessLogic
{
    ///There are three different ways for a client to 
    ///reference remote objects, and each of these is 
    ///resolved at compile time. This example uses the 
    ///first option (a).

    ///1. Compile the server object, and specify the
    ///.exe or .dll file as a reference to the compiler
    ///when you compile the client. This method is useful 
    ///when both the client and server components are 
    ///developed at the same site.

    ///2. Derive the server object from an interface class,
    ///and compile the client with the interface. This
    ///method is useful when the client and server 
    ///components are not developed at the same site. The 
    ///interface(s) can be compiled to a dynamic-link
    ///library (DLL) and shipped to the client sites as 
    ///necessary. As much as possible, avoid changing a 
    ///published interface.

    ///3. Use the SoapSUDS tool to extract the required 
    ///metadata from a running server object. This method 
    ///is useful when client and server components are 
    ///developed at different sites, and no interface 
    ///classes are available. Point the SoapSUDS tool at a
    ///remote Uniform Resource Identifier (URI), and 
    ///generate the required metadata as source or a DLL. 
    ///It is important to note that the SoapSUDS tool only 
    ///extracts metadata; it does not generate the source 
    ///for the remote object.
    class MyRemoteClient
    {
        public static void Main(string[] argv)
        {
            ///Declare a variable to initialize a TcpChannel object 
            ///that the client will use to connect to the server
            ///application. Use the RegisterChannel method to
            ///register the channel with the channel services. 
            TcpChannel chan = new TcpChannel();
            ChannelServices.RegisterChannel(chan, false);

            ///Declare and instantiate the remote server. In this 
            ///example, use the GetObject method of the Activator
            ///object to instantiate the myRemoteClass object, and
            ///specify the following parameters in the code:

            ///1. The full type name of the object that is being
            ///registered, followed by the assembly name.
            ///Specify both the name of the namespace
            ///as well as the classname. Because you did not 
            ///specify a namespace in the previous section, the
            ///default root namepace is used.
            
            ///2. Activate the URI of the object. The URI must
            ///include the protocol (TCP), the computer name
            ///(localhost), the port (8085), and the endpoint of
            ///the server object (RemoteTest). To access the
            ///ServerClass remote server that is located on the
            ///local server, use the URI tcp://localhost:8085/RemoteTest.
            MyRemoteClass myRemoteClass = (MyRemoteClass)Activator.GetObject(
    System.Type.GetType("InformationInTransit.ProcessLogic.MyRemoteClass, MyRemoteClass"),
    "tcp://localhost:8085/RemoteTest");

            if (myRemoteClass == null)
            {
	            System.Console.WriteLine("Could not locate server");
            }
            else if (myRemoteClass.SetString("Sending String to Server"))
            {
		        System.Console.WriteLine("Success: Check the other console to verify.");
            }
	        else
            {
		        System.Console.WriteLine("Sending the test string has failed.");
            }
        }
    }
}