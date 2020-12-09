using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace InformationInTransit.ProcessLogic
{
    /// <summary>
    /// Creating the remote server application
    /// After you have created the server object that the client 
    /// will communicate with, you must register this object with 
    /// the Remoting framework. When you register the object, you 
    /// must also start the server and have the server listen on a
    /// port for clients to connect to that port. To do this, you 
    /// need a project type that outputs an executable file.
    /// The reason to include the server object in a separate 
    /// project is so that you can easily reference the server 
    /// object from the client project. If you include it in this
    /// project you cannot reference it, because references can 
    /// only be set to DLL files.
    /// </summary>
    class MyRemoteServer
    {
        public static void Main(string[] argv)
        {
            ///Declare and initialize a TcpChannel object that listens for
            ///clients to connect on a certain port, which is port
            ///8085 in this example. Use the RegisterChannel method 
            ///to register the channel with the channel services.
            TcpChannel chan = new TcpChannel(8085);
            ChannelServices.RegisterChannel(chan, false);

            /*Call the RegisterWellKnownType method of the 
             * RemotingConfiguration object to register the
             * ServerClass object with the remoting framework, and
             * specify the following parameters:

             * The full type name of the object that is being 
             * registered, followed by the assembly name 
             * Specify both the name of the namespace as well as 
             * the class name here. Because you did not specify a
             * namespace in the previous section, the default root
             * namespace is used.
    
             * Name the endpoint where the object is to be 
             * published as RemoteTest. Clients need to know this 
             * name in order to connect to the object.
             
             * Use the SingleCall object mode to specify the 
             * final parameter. The object mode specifies the 
             * lifetime of the object when it is activated on 
             * the server. In the case of SingleCall objects, 
             * a new instance of the class is created for each
             * call that a client makes, even if the same client
             * calls the same method more than once. On the other
             * hand, Singleton objects are created only once, and 
             * all clients communicate with the same object.
             */ 
            
            RemotingConfiguration.RegisterWellKnownServiceType(
    System.Type.GetType("InformationInTransit.ProcessLogic.MyRemoteClass, MyRemoteClass"),
    "RemoteTest",
    WellKnownObjectMode.SingleCall);

            System.Console.WriteLine("Hit <enter> to exit...");
            System.Console.ReadLine();
        }
    }
}
