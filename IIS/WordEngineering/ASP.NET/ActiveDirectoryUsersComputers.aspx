<%@ Page Language="C#" ContentType="text/HTML" Debug="true" Explicit="true" %>

<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Web" %>

<%@ Import Namespace="InformationInTransit.ProcessLogic" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
	<head runat="Server" id="HeadBook">
		<title runat="Server" id="pageTitle">Active Directory: Users and Computers</title>
	</head>
	<body runat="server" id="BodyContact">
	<form 
		ID="FormContact" 
		runat="server"
		enctype="multipart/form-data"    
		autocomplete="on"
	>
		<asp:GridView runat="server" id="users"/>
		<asp:GridView runat="server" id="computers"/>
	</form>

	<script runat="server">
		/*
			2018-02-09	https://www.codeproject.com/Articles/489348/Active-Directory-Users-and-Computers
		*/
		protected void Page_Load
		(
			object     sender, 
			EventArgs  e
		) 
		{
			users.DataSource = ActiveDirectoryHelper.FindAllUsers();
			users.DataBind();

			computers.DataSource = ActiveDirectoryHelper.FindAllComputers();
			computers.DataBind();
		}
	</script>
 </body>
</html>
