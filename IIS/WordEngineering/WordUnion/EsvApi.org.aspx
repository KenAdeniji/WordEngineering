<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EsvApi.org.aspx.cs" Inherits="EsvApi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<link rel="stylesheet" type="text/css" href="9432.css">
		<title>EsvApi.org</title>
		<style>
			body {background: #737CA1}
		</style>
	</head>
	<body>
		<form id="form1" runat="server">
		<div>
			<table align="center">
				<tbody>
					<tr>
						<td>Query:</td>
						<td>
							<asp:TextBox runat="server" ID="query" Columns="50" />
						</td>
					</tr>
					<tr>
						<td align="center" colspan="2">
							<asp:Button runat="server" ID="submit" Text="Submit" OnClick="Submit_Click" /> 
						</td>
					</tr>
				</tbody>
			</table>
		</div>
		<div align="center">
			<asp:Literal
				runat="server"
				ID="feedback"
			/>	
		</div>
		</form>
	</body>
</html>
