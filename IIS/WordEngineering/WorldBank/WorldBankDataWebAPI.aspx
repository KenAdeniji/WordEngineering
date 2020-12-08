<%@ Page 
    Language="C#" 
    AutoEventWireup="true" 
    CodeFile="WorldBankDataWebAPI.aspx.cs"
    Inherits="WordEngineering.WorldBankDataWebAPIPage" 
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
	<head runat="Server" id="HeadBook">
		<title runat="Server" id="TitleBook">World Bank Data Web API</title>
	</head>
	<body runat="server" id="BodyContact">
	<form 
		ID="FormContact" 
		runat="server"
		enctype="multipart/form-data"    
		autocomplete="on"
	>

    <table align="center" border="0">
		<tbody>
			<tr align="center">
				<td>
					<asp:GridView
						id="WorldBankGridView" 
						runat="server" 
						AllowPaging="True"
						AllowSorting="True" 
						AutoGenerateColumns="True"
						PageSize="300"
					>
						<HeaderStyle BackColor='#CCCC99'/>
						<RowStyle BackColor='#eeeeee'/>
						<AlternatingRowStyle BackColor='#ffffe8'/>
					</asp:GridView>
				</td>
			</tr>
		</tbody>
    </table>

    <table align="center" border="0">
		<tbody> 
			<tr align="center">
				<td align="center">
					<asp:Literal 
						id="feedBack" 
						runat="server" 
						EnableViewState="False"
					/>
				</td>
			</tr>
		</tbody>    
    </table>

   </form>
 </body>
</html>
