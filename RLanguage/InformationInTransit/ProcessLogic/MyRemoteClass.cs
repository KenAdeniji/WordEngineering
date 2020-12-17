using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InformationInTransit.ProcessLogic
{
    /// <summary>
    /// The first step in creating the server application is to 
    /// create a server object. The server object is what the
    /// client application instantiates and communicates with on
    /// the server computer. The client application does this 
    /// through a proxy object that is created on the client. 
    /// In this sample, the server object resides in a Class 
    /// Library (DLL).
    /// </summary>
    public class MyRemoteClass : MarshalByRefObject
    {
        public bool SetString(String sTemp)
        {
            try
            {
                Console.WriteLine("This string '{0}' has a length of {1}", sTemp, sTemp.Length);
                return sTemp != "";
            }
            catch
            {
                return false;
            }
        }
    }
}
