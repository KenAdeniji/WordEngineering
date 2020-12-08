<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AlphabetSequence.aspx.cs" Inherits="AlphabetSequence" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" type="text/css" href="9432.css">
    <title>Alphabet Sequence</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center">
            <tbody>
                <tr>
                    <td align="center">
                        <asp:TextBox runat="server" ID="word" Columns="50" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button runat="server" ID="submit" Text="Submit" OnClick="Submit_Click" /> 
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label runat="server" ID="alphabetSequenceIndex" /> 
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Label runat="server" ID="scriptureReference" /> 
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    </form>
</body>
</html>
