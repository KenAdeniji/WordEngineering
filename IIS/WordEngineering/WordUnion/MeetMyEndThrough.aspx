<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MeetMyEndThrough.aspx.cs" Inherits="MeetMyEndThrough" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<link rel="stylesheet" href="9432.css" type="text/css" media="screen" />   
		<title>MeetMyEndThrough</title>
	</head>
	<body>
    <form id="form1" runat="server">
    <div>
        <table align="center">
            <tbody>
                <tr>
					<td>Word</td>
					<td>
                        <asp:TextBox runat="server" ID="word" Columns="30" />
                    </td>
                </tr>
                <tr>
					<td>Number</td>
					<td>
                        <asp:TextBox runat="server" ID="numberFrom" Columns="10" />
						-
                        <asp:TextBox runat="server" ID="numberUntil" Columns="10" />
                    </td>
                </tr>
                <tr>
					<td>First Occurrence</td>
					<td>
                        <asp:TextBox runat="server" ID="firstOccurrence" Columns="30" />
                    </td>
                </tr>
                <tr>
					<td>Last Occurrence</td>
					<td>
                        <asp:TextBox runat="server" ID="lastOccurrence" Columns="30" />
                    </td>
                </tr>
                <tr>
					<td>Frequency of Occurrence</td>
					<td>
                        <asp:TextBox runat="server" ID="frequencyOfOccurrenceFrom" Columns="10" />
						-
                        <asp:TextBox runat="server" ID="frequencyOfOccurrenceUntil" Columns="10" />
                    </td>
                </tr>
                <tr>
					<td>MeetMyEndThrough ID</td>
					<td>
                        <asp:TextBox runat="server" ID="meetMyEndThroughIDFrom" Columns="10" />
						-
                        <asp:TextBox runat="server" ID="meetMyEndThroughIDUntil" Columns="10" />
                    </td>
                </tr>
                <tr>
					<td>AlphabetSequenceIndex</td>
					<td>
                        <asp:TextBox runat="server" ID="alphabetSequenceIndexFrom" Columns="10" />
						-
                        <asp:TextBox runat="server" ID="alphabetSequenceIndexUntil" Columns="10" />
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
		<asp:GridView
			runat="server"
			ID="meetMyEndThroughGridView"
			AllowSorting="true" 
			OnSorting="MeetMyEndThroughGridView_Sorting"
		/>	
	</div>
    </form>
</body>
</html>
