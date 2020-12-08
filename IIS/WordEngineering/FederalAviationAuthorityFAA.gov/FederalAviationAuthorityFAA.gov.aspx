<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FederalAviationAuthorityFAA.gov.aspx.cs" Inherits="FederalAviationAuthorityFAA" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Federal Aviation Authority (FAA) Airport Status Code</title>
    <style>
        body {
            background-color: blue;
            color: yellow;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center">
        <table>
            <tr>
                <td>International Air Transport Association (IATA) Airport Code:</td>
                <td><asp:TextBox ID="iataCode" runat="server" columns="3" /></td>
            </tr>
            <tr>
                <td colspan="2">
					<asp:Button ID="querySubmit" runat="server" Text="Query" onClick="QuerySubmit_Click" />
					<button type="button" id="selectCode">Select Code</button> 
				</td>
            </tr>
            <tr>
                <td colspan="2">
                    <div style="text-align:left">
                        <fieldset>
                            <legend>Airport Status:</legend>
                            <asp:Literal ID="airportStatusOutput" runat="server" />
                        </fieldset>
                    </div>
				</td>
            </tr>
        </table>
    </div>
    </form>
	
	<script>
		function acceptCode(code)
		{
			document.getElementById("iataCode").value = code;
			document.getElementById("querySubmit").click();
		}
		
		function windowOpenSelectCode()
		{
			var windowObjectReference;
			var strWindowFeatures = "menubar=yes,location=yes,resizable=yes,scrollbars=yes,status=yes,height=500,width=500";

			windowObjectReference = window.open
			(
				"International Air Transport Association IATA 3-letter Airport Code Select.html",
				"International Air Transport Association IATA 3-letter Airport Code",
				strWindowFeatures
			);
			
			if (window.focus) {windowObjectReference.focus()}
			return false;
		}
		
		document.getElementById("selectCode").addEventListener("click", windowOpenSelectCode, "false");
	</script>
</body>
</html>

