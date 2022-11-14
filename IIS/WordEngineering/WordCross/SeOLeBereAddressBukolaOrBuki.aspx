<%@ Page 
    Language="C#"
    AutoEventWireup="true"
    CodeFile="SeOLeBereAddressBukolaOrBukiPage.aspx.cs"
    Inherits="WordEngineering.WordCross_SeOLeBereAddressBukolaOrBukiPage"
    Title="Se o le bere address Bukola or Buki?"
%>
<!--
	2022-11-13T12:37:00 Created.
	2022-11-13T15:52:00 %@ Page versus (VS) &le;%@ Page
	2022-11-13T18:57:00 
		asp:SqlDataSource
		ID="SqlDataSourceHisWord"
		ProviderName="System.Data.Odbc"
-->

<%@ Register Assembly="UtilityProtocol" Namespace="WordEngineering" TagPrefix="UtilityProtocol" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" 
"http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
	<head runat="Server" id="HeadContact">
		<title runat="Server" id="TitleContact">Se o le bere address Bukola or Buki?</title>
		<link rel="stylesheet" type="text/css" href="/WordEngineering/WordUnion/9432.css">
	</head>
	<form 
	ID="FormHisWord" 
	runat="server"
	enctype="multipart/form-data"    
	autocomplete="on"
	defaultbutton="ButtonSubmit"
	defaultfocus="TextBoxQuery"
	>
		<div align="center">
			Search Query
			<asp:TextBox
			 runat="Server"
			 ID="TextBoxQuery"
			 TabIndex="1"
			/>        
			<asp:Button runat="server" id="ButtonSubmit" onclick="ButtonSubmit_Click"  Text="Submit" TabIndex="2" />
		</div>

        <asp:SqlDataSource
			ID="SqlDataSourceHisWord"
			Runat="server"
			ConnectionString="<%$ ConnectionStrings:WordEngineering %>"
			SelectCommand="EXEC usp_SeOLeBereAddressBukolaOrBuki ?" 
			SelectCommandType="StoredProcedure"
			ProviderName="System.Data.Odbc"
        >
			<selectparameters>
				<asp:controlparameter name="query" controlid="TextBoxQuery" PropertyName="Text" ConvertEmptyStringToNull=true Type="string" Direction="Input" DefaultValue = "|" />
			</selectparameters>
		</asp:SqlDataSource>

        <asp:GridView
			id="GridViewHisWord" 
			runat="server" 
			AllowPaging="True"
			AllowSorting="True" 
			AutoGenerateColumns="True"
			AutoGenerateSelectButton="True"
			DataKeyNames="HisWordID"
			DataSourceID="SqlDataSourceHisWord"
			SelectedIndex="0"
        />

        <asp:SqlDataSource
			ID="SqlDataSourceRemember"
			Runat="server"
			ConnectionString="<%$ ConnectionStrings:WordEngineering %>"
			SelectCommand="SELECT * FROM Remember WHERE HisWordID = ?" 
			SelectCommandType="Text"
			ProviderName="System.Data.Odbc"
        >
			<selectparameters>
				<asp:ControlParameter Name="HisWordID" ControlId="GridViewHisWord" PropertyName="SelectedValue" />
			</selectparameters>
		</asp:SqlDataSource>

        <asp:GridView
			id="GridViewRemember" 
			runat="server" 
			AllowPaging="True"
			AllowSorting="True" 
			AutoGenerateColumns="True"
			DataKeyNames="RememberID"
			DataSourceID="SqlDataSourceRemember"
        />

        <asp:SqlDataSource
			ID="SqlDataSourceAPass"
			Runat="server"
			ConnectionString="<%$ ConnectionStrings:WordEngineering %>"
			SelectCommand="SELECT * FROM APass WHERE HisWordID = ?" 
			SelectCommandType="Text"
			ProviderName="System.Data.Odbc"
        >
			<selectparameters>
				<asp:ControlParameter Name="HisWordID" ControlId="GridViewHisWord" PropertyName="SelectedValue" />
			</selectparameters>
		</asp:SqlDataSource>

        <asp:GridView
			id="GridViewAPass" 
			runat="server" 
			AllowPaging="True"
			AllowSorting="True" 
			AutoGenerateColumns="True"
			DataKeyNames="APassID"
			DataSourceID="SqlDataSourceAPass"
        />
	
		<div align="center">
			<asp:Literal 
			 id="LiteralFeedback" 
			 runat="server" 
			 EnableViewState=False
			/>
		</div>
	</form>
</html>
