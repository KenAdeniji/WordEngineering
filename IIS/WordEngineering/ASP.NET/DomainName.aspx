<%@ Page Language="C#" ContentType="text/HTML" Debug="true" Explicit="true" %>

<%@ Import Namespace="System.Web" %>

<%@ Import Namespace="InformationInTransit.ProcessLogic" %>

<script runat="server">
	/*
		2017-12-15	http://www.devx.com/tips/dot-net/c-sharp/get-dns-name-from-a-httprequest-in-c-170320075508.html
	*/
	protected void Page_Load
	(
		object     sender, 
		EventArgs  e
	) 
	{
		HttpContext.Current.Response.Write
		(
			UriHelper.DomainName()
		);
	}
</script>
