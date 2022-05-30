<%@ Page Language="C#" %>

<%@ Register Assembly="Flasher" Namespace="ControlFreak" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Flash Player</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:Flasher ID="Flasher1" runat="server" FlashFile="~/Adobe/flash_crystals.swf" Width="550" Height="400" BackColor="red" />
    </div>
    <div onclick="Flasher1.Play();" style="cursor:hand">Play</div>
    <div onclick="Flasher1.Stop();" style="cursor:hand">Stop</div>
    <div onclick="alert(Flasher1.Loop);" style="cursor:hand">Loop</div>
    </form>
</body>
</html>
