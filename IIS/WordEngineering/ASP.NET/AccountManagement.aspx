<%@ Page Language="C#" ContentType="text/HTML" Debug="true" Explicit="true" %>

<%@ Import Namespace="System" %>
<%@ Import Namespace="System.Web" %>

<%@ Import Namespace="System.DirectoryServices.AccountManagement" %>

<script runat="server">
	/*
		2018-02-09	https://www.codeproject.com/Articles/42282/Get-a-User-s-Full-Name
	*/
	protected void Page_Load
	(
		object     sender, 
		EventArgs  e
	) 
	{
		try
		{
			HttpContext.Current.Response.Write("DisplayName: " + UserPrincipal.Current.DisplayName + @"<br/>");
			HttpContext.Current.Response.Write("DistinguishedName: " + UserPrincipal.Current.DistinguishedName + @"<br/>");
			HttpContext.Current.Response.Write("LastBadPasswordAttempt: " + UserPrincipal.Current.LastBadPasswordAttempt + @"<br/>");
			HttpContext.Current.Response.Write("LastLogon: " + UserPrincipal.Current.LastLogon + @"<br/>");
			HttpContext.Current.Response.Write("LastPasswordSet: " + UserPrincipal.Current.LastPasswordSet + @"<br/>");
			HttpContext.Current.Response.Write("UserPrincipalName: " + UserPrincipal.Current.UserPrincipalName + @"<br/>");
		}
		catch(Exception ex)
		{
			HttpContext.Current.Response.Write("Exception Message: " + ex.Message);
		}
	}
</script>
