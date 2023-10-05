<%@ Page
    Language="C#" 
    AutoEventWireup="true"
    CodeFile="Text-to-speech.aspx.cs"
    Inherits="TextToSpeech"
    Async="true" 
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Text-to-Speech</title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>
                    <asp:TextBox 
                        ID="text"
                        runat="server" 
                        Columns="50"
                        Rows="10" 
                        TextMode="MultiLine"
                    />
                </td>
            </tr>
            <tr>
                <td align="center">
                    <asp:Button
                        ID="speak"
                        runat="server" 
                        OnClick="Speak_Click"
                        Text="Speak"
                    />
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
