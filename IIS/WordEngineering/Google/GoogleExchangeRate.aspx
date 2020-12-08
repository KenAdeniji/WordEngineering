<%@ Page 
    Language="C#" 
    AutoEventWireup="true"
    CodeFile="GoogleExchangeRate.aspx.cs"
    Inherits="GoogleExchangeRate" 
%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
   <title>Google Exchange Rate</title>
</head>

<body>
<form runat="server">
	<table align="center">
		<tr>
			<td align="center" colspan="2">Currencies include AUD; EUR €; GBP; USD $; YEN ¥</td>
		</tr>

		<tr>
			<td>From Currency</td>
			<td>
				<asp:TextBox id="fromCurrency" runat="Server" />
			</td>
		</tr>
		<tr>
			<td>To Currency</td>
			<td>
				<asp:TextBox id="toCurrency" runat="Server" />
			</td>
		</tr>
		<tr>
			<td>From Amount</td>
			<td>
				<asp:TextBox id="fromAmount" runat="Server" />
			</td>
		</tr>
		<tr>
			<td align="center" colspan="2">
				<asp:Button 
					ID="submit"
					runat="server"
					Text="Submit"
					OnClick="Submit_Click"
				/>
			</td>
		</tr>	
	</table>
	<div align="center">
		<asp:Literal ID="feedBack" runat="server" />
	</div>	
</form>	
</body>
</html>
