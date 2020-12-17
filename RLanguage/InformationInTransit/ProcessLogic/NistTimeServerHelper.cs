using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;

namespace InformationInTransit.ProcessLogic
{
    public static partial class NistTimeServerHelper
    {
        public const string NistTimeServer = "time.nist.gov";
        public struct SystemTime				// win32 struct
        {
            public short wYear;
            public short wMonth;
            public short wDayOfWeek;
            public short wDay;
            public short wHour;
            public short wMinute;
            public short wSecond;
            public short wMilliseconds;
        };

        [DllImport("kernel32.dll")]				// function imported from kernel32.dll
        public static extern bool SetSystemTime(ref SystemTime systime); // win32 API function declaration

        public static void Main(string[] argv)
        {
            DateTime officialTime = DateTime.Now;
            DateTime localTime = DateTime.Now;
            ReadTime(out officialTime, out localTime);
			RetrieveNISTDateTime();
        }

        /*
        This is the event handler for when the "File->Get Set System Time & Update" menu item is clicked.
	    This follows the Daytime Protocol (RFC 867).  Visit www.ietf.org for more information.
	    A socket is created to the timeserver IP address at port 13.  I hard-coded the main
	    timeserver address, but other timeservers can be used, such as:

	    time-a.nist.gov		time-b.nist.gov		utcnist.colorado.edu
	    nist1.datum.com		nist1-ny.glassey.com	nist1.aol-ca.truetime.com

	    Anything (I just send the "hello" string) can be sent to the timeserver.  What's returned (in ASCII) is:

	    JJJJJ YR-MO-DA HH:MM:SS TT L H msADV UTC(NIST) OTM

	    where JJJJJ is the Modified Julian Date, YR-MO-DA is the date, HH:MM:SS is the time,
	    TT is a 2-digit indicator whether it is ST(00) or DST(50), L is whether a leap second will be added or subtracted
	    at the end of the current month, H indicates health of server, msADV is num of ms NIST advances to compensate for
	    network delays, UTC is a label always included, OTM is the on-time-marker, an '*'.
	    Once the data is received, the socket is closed.  The information is parsed and a label displays the information.
	    The SetSystemTime API function is called and the system time is updated.
        */

        public static void ReadTime
        (
            out DateTime officialTime,
            out DateTime localTime
        )
        {
            string returndata = null;			    // bytes returned from timeserver
            string[] dates = new string[4];			// year, month, day
            string[] times = new string[4];			// hour, minute, second
            string[] tokens = new string[11];		// bytes tokenized

            officialTime = DateTime.Now;
            localTime = DateTime.Now;

            TcpClient tcpClient = new TcpClient();	// create new socket object

            try
            {
                tcpClient.Connect(NistTimeServer, 13);	// try to connect to timeserver

                NetworkStream networkStream = tcpClient.GetStream(); // socket stream

			    if (networkStream.CanWrite && networkStream.CanRead) // stream is ready
			    {
				    // the hello string, Can be anything!
                    Byte[] sendBytes = Encoding.ASCII.GetBytes("Hello");

				    // send to timeserver
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
      	
    				byte[] bytes = new byte[tcpClient.ReceiveBufferSize];

                    // the officialTime timeserver data
	    			networkStream.Read(bytes, 0, (int) tcpClient.ReceiveBufferSize);

                    // cast as ASCII string
				    returndata = Encoding.ASCII.GetString(bytes);
			    }

			    tcpClient.Close();			// close socket
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
				
				if (tcpClient != null)
                {
                    tcpClient.Close();
                    return;
                }
            }

            tokens = returndata.Split(' '); // the timeserver data space parsed
            dates = tokens[1].Split('-');			// the date info hypen parsed
            times = tokens[2].Split(':');			// the time info colon parsed

            // create a new datetime object with these values
            officialTime =  new DateTime
            (
                Int32.Parse(dates[0]) + 2000,
                Int32.Parse(dates[1]),
                Int32.Parse(dates[2]),
                Int32.Parse(times[0]),
                Int32.Parse(times[1]),
                Int32.Parse(times[2])
            );

            localTime = TimeZone.CurrentTimeZone.ToLocalTime(officialTime);

            System.Console.WriteLine
            (
                "Official time: {0} | local time: {1}",
                officialTime,
                localTime
            );

            // create systemtime object
            SystemTime systime = new SystemTime();

            // set struct with correct values
            systime.wYear = (short)officialTime.Year;
            systime.wMonth = (short)officialTime.Month;
            systime.wDay = (short)officialTime.Day;
            systime.wHour = (short)officialTime.Hour;
            systime.wMinute = (short)officialTime.Minute;
            systime.wSecond = (short)officialTime.Second;

            // win32 API function to set system time (in UTC)
            SetSystemTime(ref systime);
        }
		
		///<remarks>
		///	http://csharphelper.com/blog/2014/11/get-the-current-time-from-the-nist-server-in-c/
		///</remarks>
		public static DateTime RetrieveNISTDateTime()
		{
			//Create and instance of a TCP client that will connect to the server 
			//and get the information it offers
			System.Net.Sockets.TcpClient tcpClientConnection = new System.Net.Sockets.TcpClient();

			String fullDateTime = null;
			String partialDateTime = null;
			DateTime nistDateTime = DateTime.Now;
			
			//Attempt to connect to the NIST server. If it succeeds, the flag is set 
			//to collect the information from the server.
			try
			{
				tcpClientConnection.Connect(Server, Port);

				NetworkStream netStream = tcpClientConnection.GetStream();

				//Check the flag the states if you can read the stream or not
				if (netStream.CanRead)
				{
					//Get the size of the buffer
					byte[] bytes = new byte[tcpClientConnection.ReceiveBufferSize];

					//Read in the stream to the length of the buffer
					netStream.Read(bytes, 0, tcpClientConnection.ReceiveBufferSize);

					//Read the Bytes as ASCII values and build the stream
					// of characters that are the date and time from NIST. 
					fullDateTime = Encoding.ASCII.GetString(bytes).Substring(0, 50);

					//Convert the string to a date time value
					partialDateTime = fullDateTime.Substring(7, 17);
					nistDateTime = DateTime.Parse("20" + partialDateTime);

					//Advise the user of the situation
					tcpClientConnection.Close(); //close the client stream
					netStream.Close(); //close the network stream
				}
				
				//Uses the Close public method to close the network stream and socket.
				tcpClientConnection.Close();
			}
			//Provide the user feedback if the TCP client couldn't
			// even get the stream of data from the server.
			catch (ArgumentNullException e)
			{
				// show error messages when appropriate
				System.Console.WriteLine("ArgumentNullException: {0}", e.ToString());
			}
			catch (SocketException e)
			{
				// show error messages when appropriate
				System.Console.WriteLine("SocketException: {0}", e.ToString());
			}
			
			System.Console.WriteLine(nistDateTime);
			
			return nistDateTime;
		}

		//Server addresses and information from //http://tf.nist.gov/tf-cgi/servers.cgi
		public const string Server = "time.nist.gov"; //URL to connect to the server
		public const Int32 Port = 13; //port to get date time data from the server
		
	}	
}
