<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InSeldomWeekInComputerTermsWhatIsItCalled.aspx.cs" Inherits="InSeldomWeekInComputerTermsWhatIsItCalledPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" type="text/css" href="9432.css">
    <title>In seldom week, in computer terms, what is it called?</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align=center>
        <asp:TextBox 
            ID="question"
            runat="server"
			columns="50"
        />                        
        <asp:Button
            ID="submit"
			runat="server"
			OnClick="Submit_Click"
			Text="Submit"
		/>
		
		<br /><br />
		<asp:GridView
			id="jamesStrongConcordance" 
			runat="server"
			caption="James Strong Exhaustive Concordance of Greek and Hebrew Words"
		/>
		
		<br /><br />
		<asp:GridView
			id="biblicalName" 
			runat="server"
			caption="Hitchcock Biblical Name"
		/>

		<br /><br />
		<asp:GridView
			id="easton" 
			runat="server"
			caption="Easton" 
		/>

		<br /><br />
		<asp:GridView
			id="naveTopicalBible" 
			runat="server"
			caption="Nave Topical Bible" 
		/>

		<br /><br />
		<asp:GridView
			id="raTorrey" 
			runat="server"
			caption="R.A. Torrey the New Topical Textbook"
		/>
	</div>
    </form>
</body>
</html>
