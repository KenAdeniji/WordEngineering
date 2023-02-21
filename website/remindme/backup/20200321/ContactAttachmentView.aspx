<%@ Page language="c#" 
        Src="ContactAttachmentView.cs" 
        Inherits="DBImages.ViewImage" %>
<%@ OutputCache duration="180" varybyparam="documentAttachmentIdentifier" %>        
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html>
<head>
<title>
Contact Attachment View
</title>
</head>
<body>

  <form id="ViewImage" 
        method="post" 
        runat="server">
  </form>
  
</body>
</html>