<html>
	<head>
		<title>Hello World. Web Service Requestor. Using jQuery</title>
		<script type="text/javascript" src="Scripts/jquery-1.7.1.min.js"> </script>
		 <script language="javascript" type="text/javascript">
			function CallWebServiceFromJquery() {
            
            $.ajax({
                type: "POST",
                url: "HelloWorld.asmx/PrintMessage",
                data: "{}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                error: OnError
            });
		}
 
        function OnSuccess(data, status)
        {
           alert(data.d);
        }
 
        function OnError(request, status, error)
        {
            alert(request.statusText);
        }

		</script>

	</head>
	<body>
		<form id="form1" runat="server">
			<asp:Button ID="btnCallWebService" runat="server" 	OnClientClick="CallWebServiceFromJquery()"    Text="Call Webservice"/>
		</form>
	</body>
</html>
	