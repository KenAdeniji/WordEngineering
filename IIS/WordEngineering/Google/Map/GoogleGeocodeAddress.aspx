<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoogleGeocodeAddress.aspx.cs" Inherits="GoogleGeocodeAddress" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
	<head runat="server">
		<meta http-equiv="content-type" content="text/html; charset=UTF-8″ />
		<title>Google Geocode Address</title>
	</head>
<body>
	<form runat="server">
		<table>
			<tr>
				<td align="center" colspan="2">
					<asp:Label ID="labelAddress" runat="Server" AssociatedControlID="address">Address:</asp:Label>
					<asp:TextBox ID="address" runat="Server">Toronto</asp:TextBox>
					<asp:Button ID="submit" Text="Submit" runat="Server" OnClick="Submit_Click" />
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="labelLatitude" runat="Server" AssociatedControlID="latitude">Latitude:</asp:Label>
				</td>
				<td>	
					<asp:Label ID="latitude" runat="Server" />
				</td>
			</tr>
			<tr>
				<td>
					<asp:Label ID="labelLongitude" runat="Server" AssociatedControlID="longitude">Longitude:</asp:Label>
				</td>
				<td>	
					<asp:Label ID="longitude" runat="Server" />
				</td>
			</tr>
	</form>
</body>
</html>
