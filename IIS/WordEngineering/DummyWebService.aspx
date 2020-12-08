<%@ Page Language="C#" %>
<%@ Import Namespace="System.Web.Services" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head id="Head1" runat="server">
<title>ASP.NET AJAX Web Services: Web Service Sample Page</title>
 <script type="text/javascript"  src="http://code.jquery.com/jquery-latest.js">   
</script>  
  <script type="text/javascript">
      function OnSayHelloClick() {
          var txtName = $get("name");
          DummyWebservice.HelloToYou(txtName.value, SayHello);
      }
      function SayHello(result) {
          alert(result);
      }
  </script>  
</head>
<body>
   <form id="form1" runat="server">
    <asp:ScriptManager ID="_scriptManager" runat="server">
      <Services>
        <asp:ServiceReference Path="DummyWebsevice.asmx" />
      </Services>
    </asp:ScriptManager>
    <h1> ASP.NET AJAX Web Services: Web Service Sample Page </h1>
     Enter your name: 
        <input id="name" />
        <br />
        <input id="sayHelloButton" value="Say Hello"
               type="button" onclick="OnSayHelloClick();" />
    </form>
</body>
</html>
