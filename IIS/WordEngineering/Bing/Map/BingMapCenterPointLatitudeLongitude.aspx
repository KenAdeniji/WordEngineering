<%@ Page
    Language="C#"
    AutoEventWireup="true"
    CodeFile="BingMapCenterPointLatitudeLongitude.aspx.cs"
    Inherits="Bing_Map_BingMapCenterPointLatitudeLongitude" 
    Debug="true"
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Bing Map Center Point Latitude and Longitude</title>
</head>
<body>
    <form id="form1" runat="server">
    <table align="center">
        <tbody>
            <tr align="center">
                <td><asp:Label runat="server" ID="labelLatitude" Text="Latitude" AssociatedControlID="latitude" /></td>
                <td><asp:TextBox runat="server" ID="latitude" /></td>
            </tr>
            <tr align="center">
                <td><asp:Label runat="server" ID="labelLongitude" Text="Longitude" AssociatedControlID="longitude" /></td>
                <td><asp:TextBox runat="server" ID="longitude" /></td>
            </tr>
            <tr align="center">
                <td><asp:Label runat="server" ID="labelDescription" Text="Description" AssociatedControlID="description" /></td>
                <td><asp:TextBox runat="server" ID="description" /></td>
            </tr>
            <tr align="center">
                <td colspan="2">
                    <asp:Button runat="server" ID="buttonQuery" Text="Query" OnClick="Query_Click" />
                    <asp:Button runat="server" ID="buttonAddPoint" Text="Add Point" OnClick="AddPoint_Click" />
                </td>
            </tr>
        </tbody>
    </table>
    <div>
    <iframe runat="server" id="iframeBing" src="http://www.bing.com/maps/default.aspx?cp=47.677797~-122.122013" width="100%" height="100%">
        <p>Your browser does not support iframes.</p>
    </iframe>
    </div>
    <div>
        <asp:GridView
            runat="server"
            ID="gridViewGeometryPoint"
            AutoGenerateColumns="False"
            DataKeyNames="Id"
            AllowPaging="True"
            AllowSorting="True"
            AutoGenerateSelectButton="true"
            PageSize="10" 
            OnPageIndexChanging="GridViewGeometryPoint_PageIndexChanging" 
            OnSelectedIndexChanged="GridViewGeometryPoint_SelectedIndexChanged"
            OnSorting="GridViewGeometryPoint_Sorting"
        >
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" />
                <asp:BoundField DataField="Dated" HeaderText="Dated" SortExpression="Dated" />
                <asp:BoundField DataField="Points" HeaderText="Points" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
