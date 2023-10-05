<%@ WebService Language="C#" Class="WordEngineering.DummyWebService" %>

using System.Web.Services;

namespace WordEngineering
{
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.Web.Script.Services.ScriptService]
	public class DummyWebService : System.Web.Services.WebService
	{
	  [WebMethod()]
	  public string HelloToYou(string name)
	  {
		  return "Hello " + name;
	  }

	  [WebMethod()]
	  public string SayHello()
	  {
		  return "hello ";
	  }  
	}
}
