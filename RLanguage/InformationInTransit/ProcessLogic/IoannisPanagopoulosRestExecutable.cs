using System;
using System.ServiceModel.Activation;
using System.ServiceModel;
using System.ServiceModel.Web;

///<remarks>
///		http://www.progware.org/Blog/post/A-simple-REST-service-in-C.aspx
///		netstat -anb | findstr ":81"
///		http://localhost:81/IoannisPanagopoulosRestServices/client/22
///</remarks>
public static partial class IoannisPanagopoulosRestExecutable
{
	static void Main(string[] args)
	{
		IoannisPanagopoulosRestServices ioannisPanagopoulosRestServices = new IoannisPanagopoulosRestServices();
		WebServiceHost _serviceHost = new WebServiceHost
		(
			ioannisPanagopoulosRestServices, 
			new Uri("http://localhost:81/IoannisPanagopoulosRestServices")
		);
		_serviceHost.Open();
		Console.ReadKey();
		_serviceHost.Close();
	}
}
