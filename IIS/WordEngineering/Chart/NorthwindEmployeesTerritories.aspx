<%@ Page
    Language="C#" 
    AutoEventWireup="true"
    CodeFile="NorthwindEmployeesTerritories.aspx.cs"
    Inherits="Chart_NorthwindEmployeesTerritories" 
    Debug="true"
%>

<%@ Register
    Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" 
    TagPrefix="asp" 
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Database: Northwind | Tables: Employees, EmployeeTerritories | Group: EmployeeID, FirstName, LastName</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Chart 
        ID="SampleChart"
        runat="server" 
        DataSourceID="BackendDataSource"
        Height="296px" 
        Width="412px"
        ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" 
        Palette="BrightPastel" 
        imagetype="Png" 
        BorderDashStyle="Solid"
        BackSecondaryColor="White"
        BackGradientStyle="TopBottom"
        BorderWidth="2"
        backcolor="#D3DFF0"
        BorderColor="26, 59, 105"
    >
        <legends>
            <asp:Legend
                IsTextAutoFit="False"
                Name="Default"
                BackColor="Transparent"
                Font="Trebuchet MS, 8.25pt, style=Bold"
            />
        </legends>
        <borderskin skinstyle="Emboss" />
        <series>
            <asp:Series 
                Name="Territory Series"
                BorderColor="180, 26, 59, 105"
                ChartType="Column"
                XValueMember="EmployeeName"
                YValueMembers="TerritoryCount"
            />
        </series>
        <chartareas>
            <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="64, 165, 191, 228" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                <area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
                <axisy linecolor="64, 64, 64, 64" title="# of Territories">
                    <labelstyle font="Trebuchet MS, 8.25pt, style=Bold" Interval="1"  />
                    <majorgrid linecolor="64, 64, 64, 64" />
                </axisy>
                <axisx linecolor="64, 64, 64, 64" Title="Employee">
                    <labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
                    <majorgrid linecolor="64, 64, 64, 64" />
                </axisx>
            </asp:ChartArea>
        </chartareas>

    </asp:Chart>
    <asp:SqlDataSource
        ID="BackendDataSource"
        runat="server"
        ConnectionString="<%$ ConnectionStrings:Northwind %>"
        SelectCommand=
        "
        SELECT
            Employees.FirstName + ' ' + Employees.LastName AS EmployeeName,
            COUNT(*) AS TerritoryCount 
        FROM 
            Employees JOIN EmployeeTerritories ON Employees.EmployeeID = EmployeeTerritories.EmployeeID 
        GROUP BY 
            Employees.EmployeeID,
            Employees.FirstName,
            Employees.LastName
        "
    />
    </div>
    </form>
</body>
</html>
