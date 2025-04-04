﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WordEntrance.aspx.cs" Inherits="WordEntrance" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" type="text/css" href="9432.css">
    <title>WordEntrance</title>
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
					<td>First Occurrence</td>
					<td>
                        <asp:TextBox runat="server" ID="firstOccurrenceFrom" Columns="10" />
						-
						<asp:TextBox runat="server" ID="firstOccurrenceUntil" Columns="10" />
                    </td>
                </tr>
                <tr>
					<td>Last Occurrence</td>
					<td>
                        <asp:TextBox runat="server" ID="lastOccurrenceFrom" Columns="10" />
						-
						<asp:TextBox runat="server" ID="lastOccurrenceUntil" Columns="10" />
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
					<td>SequenceOrderId</td>
					<td>
                        <asp:TextBox runat="server" ID="sequenceOrderIdFrom" Columns="10" />
						-
                        <asp:TextBox runat="server" ID="sequenceOrderIdUntil" Columns="10" />
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
			ID="wordEntranceGridView"
			AllowSorting="true" 
			OnSorting="WordEntranceGridView_Sorting"
		/>	
	</div>
    </form>
</body>
</html>
