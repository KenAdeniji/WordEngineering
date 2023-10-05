<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FreeTextSearch.aspx.cs" Inherits="FreeTextSearchPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<link rel="stylesheet" type="text/css" href="9432.css">
    <title>Free-Text Search</title>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center">
        <asp:TextBox 
            ID="question"
            runat="server"
			columns="50"
        />
		<select id="andOrPhrase" runat="server">
		  <option value="and">And</option>		
		  <option value="or">Or</option>
		  <option value="phrase">Phrase</option>
		</select>
		<asp:Button
            ID="submit"
			runat="server"
			OnClick="Submit_Click"
			Text="Submit"
		/>
		<br />
		<input type="checkbox" id="collate" onclick="combine();"/>		
		<label for="collate">Scripture reference concatenate visible</label>
 		<br />
	</div>	
	<div align="center">	
		<asp:GridView
			runat="server"
			ID="resultSet"
		>
			<HeaderStyle BackColor='yellow' ForeColor='gray'/>
			<RowStyle BackColor='blanchedalmond' ForeColor='blue'/>
			<AlternatingRowStyle BackColor='beige' ForeColor='black'/>
		</asp:GridView>
	</div>	
	<div
		id="scriptureReferenceCollate"
		align="center"
	>	
	</div>	
    </form>

	<script>
	function combine()
	{
		var collate = document.getElementById('collate').checked;
		var scriptureReferenceCollate = document.getElementById('scriptureReferenceCollate');
		
		var concatenate="";
				
		if (collate === true)
		{
			var table=document.getElementById("resultSet");
			var r=1;
			
			while(row=table.rows[r++])
			{
				var scriptureReference = row.cells[0].innerHTML;
				if (concatenate != "")
				{
					concatenate += ", ";
				}
				concatenate += scriptureReference;
			}
			scriptureReferenceCollate.innerHTML = concatenate;
			scriptureReferenceCollate.style.visibility='visible';
		}
		else
		{
			scriptureReferenceCollate.innerHTML = "";
			scriptureReferenceCollate.style.visibility='hidden';
		}
	}
	</script>
</body>
</html>
