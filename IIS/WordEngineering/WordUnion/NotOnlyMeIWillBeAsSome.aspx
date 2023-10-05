<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NotOnlyMeIWillBeAsSome.aspx.cs" Inherits="NotOnlyMeIWillBeAsSomePage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" type="text/css" href="9432.css">
    <title>Not Only Me; I Will Be As Some</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align=center>
		<asp:Label
			for="question"
		>
			Scripture Reference:
		</asp:Label>
		<asp:TextBox 
            ID="question"
            runat="server"
			columns="70"
        />

		<asp:Label
			for="frequencyOfOccurrenceLimit"
		>
			Frequency of Occurrence Limit:
		</asp:Label>
		
        <asp:TextBox 
            ID="frequencyOfOccurrenceLimit"
            runat="server"
			columns="5"
        />                        
        <asp:Button
            ID="submit"
			runat="server"
			OnClick="Submit_Click"
			Text="Submit"
		/>
		<br/><br/>
		<asp:GridView
			id="informationSet" 
			runat="server"
			caption="Frequency of Occurrence"
		/>
    </div>
    </form>
</body>
</html>
