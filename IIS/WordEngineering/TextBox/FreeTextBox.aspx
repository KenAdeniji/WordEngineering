<%@ Page Language="C#" ValidateRequest="false" Debug="true" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<script runat="server">

protected void Page_Load(Object Src, EventArgs E) {
	if (!IsPostBack) {

		FreeTextBox1.FontFacesMenuList = new string[] { "Arial", "Times" };

		FreeTextBox1.Text = "<p>some <b>Bold</b> and <u>underlined</u> and <font color=\"#008000\">colored</font> text<p><ul><li>bulleted list 1</li></ul>";
	}
}

protected void SaveButton_Click(Object Src, EventArgs E) {

	Output.Text = FreeTextBox1.Text;
}

</script>
<html>
<head>
	<title>Custom DropDownList values</title>
<script>

</script>
</head>
<body>

    <form id="Form1" runat="server">
    	
    	<h2>Custom DropDownList values</h2>
    	
    	<div>		
			<FTB:FreeTextBox
                id="FreeTextBox1"
                runat="Server"
                Focus="true" 
                toolbarlayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu,FontForeColorPicker,FontBackColorsMenu,FontBackColorPicker|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage|Cut,Copy,Paste,Delete;Undo,Redo,Print,Save|SymbolsMenu,StylesMenu,InsertHtmlMenu|InsertRule,InsertDate,InsertTime|InsertTable,EditTable;InsertTableRowAfter,InsertTableRowBefore,DeleteTableRow;InsertTableColumnAfter,InsertTableColumnBefore,DeleteTableColumn|InsertForm,InsertTextBox,InsertTextArea,InsertRadioButton,InsertCheckBox,InsertDropDownList,InsertButton|InsertDiv,EditStyle,InsertImageFromGallery,Preview,SelectAll,WordClean,NetSpell"
            />				
			<asp:Button id="SaveButton" Text="Save" onclick="SaveButton_Click" runat="server" />
		</div>
		
		<div>
			<asp:Literal id="Output" runat="server" />
		</div>
	</form>
</body>
</html>
